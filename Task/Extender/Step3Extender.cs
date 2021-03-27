using Soneta.Business;
using Task.Business;
using Task.Extender;

[assembly: Worker(typeof(Step3Extender))]

namespace Task.Extender {
    public partial class Step3Extender : ContextBase {

        private Params _parameters;

        public Step3Extender(Context cx) : base(cx) {
        }

        public Params FilterParameters => _parameters ?? (_parameters = new Params(Context));

        public TaskProxy[] Tasks {
            get {
                checkBuffer();
                if (tasks == null) {
                    RefreshTasks();
                }
                return tasks;
            }
        }
    }
}
