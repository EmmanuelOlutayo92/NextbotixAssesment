using NexBotixWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace NexBotixWebApp.Services
{
    public class GetData : IGetData
    {
        private readonly HttpClient _httpClient;
        public GetData(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public IEnumerable<TableOutputModel> DataOutput() 
        {
            int i = 0;
            var postLists = PostDictionary();
            var commentsDict = CommentDictionary();
            var output = new List<TableOutputModel>();
            

            foreach (var t in postLists)
            {
                int count = 0;
                Console.WriteLine(t.Key);
                List<PostViewModel> newList = t.Value.ToList();
                foreach (var r in newList)
                {

                    foreach (var s in commentsDict)
                    {
                        if (r.id == s.Key)
                        {
                            count += s.Value;
                        }
                    }
                }
               
                output.Add(new TableOutputModel
                {
                    UserId = t.Key,
                    TotalPosts = t.Value.ToList().Count(),
                    TotalCommentsForAllPosts = count
                });

                i++;
            }
            return output.ToList();
        }

        private Dictionary<int, List<PostViewModel>> PostDictionary()
        {
            var postList = GetItemsFromEndPoint<PostViewModel>("/posts").GetAwaiter().GetResult();
            var dict = new Dictionary<int, int>();

            var dictUpdate = new Dictionary<int, List<PostViewModel>>();
            foreach (var item in postList)
            {
                dict.TryGetValue(item.userId, out int count);
                dict[item.userId] = count + 1;
            }
            foreach (var i in dict)
            {
                List<PostViewModel> updatedList = postList.Where(a => a.userId == i.Key).ToList();
                dictUpdate[i.Key] = updatedList;
            }

            return dictUpdate;
        }

        private Dictionary<int, int> CommentDictionary()
        {
            var commentList = GetItemsFromEndPoint<CommentViewModel>("/comments").GetAwaiter().GetResult();
            var dict = new Dictionary<int, int>();
            foreach (var item in commentList)
            {
                dict.TryGetValue(item.postId, out int count);
                dict[item.postId] = count + 1;
            }
            return dict;
        }
        public async Task<List<T>> GetItemsFromEndPoint<T>(string endpoint)
        {
            List<T> OutputList = null;

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                OutputList = JsonSerializer.Deserialize<List<T>>(data);
            }
            return OutputList;
        }
    }
}
