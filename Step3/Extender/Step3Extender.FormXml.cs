using Soneta.Business.UI;

namespace Task.Extender {
    public partial class Step3Extender {
        private GroupContainer root;

        public UIElement GetStackElement() {
            checkBuffer();
            if (root == null) {
                root = new GroupContainer {
                    CaptionHtml = "Zadanie rekrutacyjne",
                    Height = "*",
                    Width = "*"
                };

                root.Elements.Add(new GapElement { Height = "1", Width = "1" });
                root.Elements.Add(GetGroupElements());
            }
            return root;
        }

        private UIElement GetGroupElements() {
            var flow = new FlowContainer();
            var tasks = Tasks;
            for (var i = 0; i < tasks.Length; i++) {
                flow.Elements.Add(getUIElement(i));
            }
            return flow;
        }

        private UIElement getUIElement(int i) {
            var env = new EnvironmentExtender();
            var row = new RowContainer();
            var group = new GroupContainer {
                DataContext = "{Tasks[" + i + "]}",
                CaptionHtml = "{Title}",
                Width = "350px",
                Height = "80px"
            };

            var stackRight = new StackContainer {
                LabelWidth = "20",
            };

            var labelAddress2 = new LabelElement {
                CaptionHtml = "{Commit.Description}",
                Width = "100"
            };

            stackRight.Elements.Add(labelAddress2);

            row.Elements.Add(stackRight);

            if (env.IsHtml) 
                stackRight.Class = new[] { UIClass.Tight };
            
            group.Elements.Add(row);
            group.Elements.Add(new GapElement {
                Height = "1",
                Width = "0"
            });

            return group;
        }
    }
}
