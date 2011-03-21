using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace MMFR{

    public partial class frmMain : Form{

        private FileInfo[] mDataFiles;
        private ArrayList mDefaultFiles = new ArrayList();
        BackgroundWorker mBackgroundWorker;

        static ulong mAlreadyDeleted = 0;

        public frmMain(){
            InitializeComponent();
           
            //Prestartup checks
            if (!Directory.Exists("Data Files"))
                throw new Exception("Cannot find data files directory");
            
            //Load the data file
            if (!File.Exists("MMFR.dat"))
                throw new Exception("Cannot find MMFR data file");
            StreamReader sr;
            sr = File.OpenText("MMFR.dat");
            while ( !sr.EndOfStream ){
                mDefaultFiles.Add(sr.ReadLine());
            }

        }

        /**
         * Gets a list of all the files in the data files directory
         * */
        private void getDirectoryData(){
            DirectoryInfo d = new DirectoryInfo("Data Files");
            mDataFiles = d.GetFiles("*", SearchOption.AllDirectories);
        }

        /**
         * Starts the thread than handles the deleting of files
         * */
        private void btnDel_Click(object sender, EventArgs e){

            lblFilesProc.Text = "0";
            lblFilesDel.Text = "0";
            lblTotalFiles.Text = "0";

            btnDel.Enabled = false;
            btnStop.Enabled = true;

            mBackgroundWorker = new BackgroundWorker();

            mBackgroundWorker.WorkerReportsProgress = true;
            mBackgroundWorker.WorkerSupportsCancellation = true;

            mBackgroundWorker.DoWork += deleteFiles;
            mBackgroundWorker.ProgressChanged += deleteFiles_ProgressChanged;
            mBackgroundWorker.RunWorkerCompleted += deleteFiles_WorkerDone;

            mBackgroundWorker.RunWorkerAsync();
        }



        /**
         * deletes every file not in mDefaultFiles
         * */
        private void deleteFiles(object sender, DoWorkEventArgs e){
            getDirectoryData();

            if (mDataFiles.Length == 0)
                return;

            int counter = 0;
            float done;
            ulong deletedFiles = mAlreadyDeleted;
            ulong processedFiles = mAlreadyDeleted;
            //for ( ulong i = 0; i < mDataFiles.Length; ++i){
            foreach( FileInfo f in mDataFiles ){
                done = (float)(processedFiles) / (float)mDataFiles.Length * (float)100;

                if (mBackgroundWorker.CancellationPending){
                    e.Cancel = true;
                    return;
                }

                String path = f.FullName.Replace(Directory.GetCurrentDirectory(), "");

                if ( !mDefaultFiles.Contains(path)){
                    if (f.Exists){
                        f.Delete();
                        deletedFiles++;
                    }
                }
                processedFiles++;

                if (counter < 150)
                    counter++;
                else{
                    counter = 0;
                    if (done > 100) done = 100;
                    mBackgroundWorker.ReportProgress((int)done, new ProgressData(processedFiles, deletedFiles));
                }
            }

            //final update
            done = (float)(processedFiles) / (float)mDataFiles.Length * (float)100;
            if (done > 100) done = 100;
            mBackgroundWorker.ReportProgress((int)done, new ProgressData(processedFiles, deletedFiles));

            //clean up directies
            DirectoryInfo di = new DirectoryInfo("Data Files");
            deleteEmptyDirs(di.FullName);
        }

        /**
         * Deletes every empty directory in the given path
         * */
        private void deleteEmptyDirs(String path){
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories();

            foreach( DirectoryInfo d in dirs ){
                deleteEmptyDirs(d.FullName);
                if ( d.GetDirectories().Length == 0 && d.GetFiles().Length == 0 ){
                    d.Delete();
                }
            }
        }

        /** 
         * Stops the deleting thread
         * */
        private void btnStop_Click(object sender, EventArgs e){
            mBackgroundWorker.CancelAsync();
        }

        /**
         * Updates the UI with the info sent to it from the del thread
         * */
        private void deleteFiles_ProgressChanged(object sender,  ProgressChangedEventArgs e){


            ProgressData a = (ProgressData)e.UserState;
            lblFilesProc.Text = Convert.ToString(a.FilesProcessed);
            lblFilesDel.Text = Convert.ToString(a.FilesDeleted);
            lblTotalFiles.Text = Convert.ToString(mDataFiles.Length);
            
            prgMain.Value = e.ProgressPercentage;

        }

        /** 
         * Called when the worker thread is finsihed. Reanbles some buttons
         * */
        private void deleteFiles_WorkerDone(object sender, RunWorkerCompletedEventArgs e){
            btnDel.Enabled = true;
            btnStop.Enabled = false;
            if (e.Error != null)
                MessageBox.Show("Worker exception: " + e.Error.ToString());
        }
    }

    public class ProgressData
    {
        public ProgressData(ulong a, ulong b)
        {
            FilesProcessed = a;
            FilesDeleted = b;
        }
        public ulong FilesProcessed = 0;
        public ulong FilesDeleted = 0;
    };
}