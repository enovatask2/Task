using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL;

namespace Task.Business
{
    public class GithubDataGetter
    {
        private readonly string urlForBranches = "https://api.github.com/repos/enovatask2/task/branches";
        private readonly string urlForCommits = "https://api.github.com/repos/enovatask2/task/commits?sha=";

        public List<CommitRoot> GetCommitsFromAllBranches()
        {
            List<CommitRoot> results = new List<CommitRoot>();

            List<BranchRoot> branches = getBranches();

            foreach (var branch in branches)
            {
                results.AddRange(getCommits(branch.name));
            }

            return results;
        }
        private List<BranchRoot> getBranches()
        {
            var client = new RestClient(urlForBranches);
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<BranchRoot>>(response.Content);
        }
        private List<CommitRoot> getCommits(string branchName)
        {
            var client = new RestClient($"{urlForCommits}{branchName}");
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<CommitRoot>>(response.Content);
        }
    }
}
