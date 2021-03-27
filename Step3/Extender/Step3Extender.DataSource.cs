using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Soneta.Business;
using Soneta.Types;
using Soneta.Zadania;
using Task.Business;
using Task.DAL;

namespace Task.Extender {
    public partial class Step3Extender{
        private TaskProxy[] tasks;
        private YearMonth recentMonth;

        public void RefreshTasks() {
            if (!FilterParameters.NeedRefresh) {
                return;
            }
            FilterParameters.NeedRefresh = false;

            var list = new List<TaskProxy>();
         
            GithubDataGetter dataGetter = new GithubDataGetter();
            List<CommitRoot> commits = dataGetter.GetCommitsFromAllBranches();

            CommitCounter commitWorker = new CommitCounter(commits);
            List<CommitInfo> results = commitWorker.PrepareDataForShow();

            foreach (CommitInfo result in results) {
                list.Add(new TaskProxy(result, Context));
            }
            tasks = list.ToArray();
        }


        private void checkBuffer() {
            if (FilterParameters.Month != recentMonth) {
                root = null;
                tasks = null;
                recentMonth = FilterParameters.Month;
            }
        }
    }
}
