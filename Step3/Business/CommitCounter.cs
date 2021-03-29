using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL;

namespace Task.Business
{
    public class CommitCounter
    {
        private List<CommitRoot> commits;
        public CommitCounter(List<CommitRoot> commits)
        {
            this.commits = commits;
        }

        public List<CommitInfo> PrepareDataForShow()
        {
            List<CommitInfo> result = countCommitsPerUserAndDay(commits);
            result = sortData(result);
            countAverageCommits(result);

            return result;
        }

        private List<CommitInfo> countCommitsPerUserAndDay(List<CommitRoot> commits)
        {
            return commits.GroupBy(c => new
            {
                c.commit.committer.name,
                c.commit.committer.date.Date,
            }).Select(gcs => new CommitInfo()
            {
                WhoCommit = gcs.Key.name,
                DateCommit = gcs.Key.Date,
                Quantity = gcs.Count()
            }).ToList();
        }

        private void countAverageCommits(List<CommitInfo> result)
        {
            foreach (var person in result.GroupBy(x => x.WhoCommit).Select(x => x.FirstOrDefault()))
            {
                DateTime minDate = result.Where(x => x.WhoCommit == person.WhoCommit).Min(x => x.DateCommit);
                DateTime maxDate = result.Where(x => x.WhoCommit == person.WhoCommit).Max(x => x.DateCommit);
                double days = (maxDate - minDate).TotalDays + 1;

                int commitSum = result.Where(x => x.WhoCommit == person.WhoCommit).Sum(x => x.Quantity);

                result.FirstOrDefault(x => x.WhoCommit == person.WhoCommit).AverageQuantity = commitSum / days;
            }
        }

        private List<CommitInfo> sortData(List<CommitInfo> result)
        {
            return result.OrderBy(x => x.DateCommit).ToList();
        }
    }
}
