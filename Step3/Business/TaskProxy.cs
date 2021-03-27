using System;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Core;
using Soneta.Zadania;
using Task.DAL;

namespace Task.Business {
    public class TaskProxy {
        private readonly CommitInfo commitInfo;
        private readonly Context context;

        public TaskProxy(CommitInfo zd, Context cx) {
            commitInfo = zd;
            context = cx;
        }

        public string Title => $"Termin spotkania: ";

        public CommitInfo Commit => commitInfo;

    }
}
