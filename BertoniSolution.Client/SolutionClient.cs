using BertoniSolution.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BertoniSolution.Client
{
    public class SolutionClient : BertoniSolClient, ISolutionClient
    {
        public SolutionClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<AlbumEL>> GetAlbum()
        {
            var vUrl = "albums";
            var vProcess = await Get<List<AlbumEL>>(vUrl);
            return vProcess;
        }

        public async Task<List<PhotoEL>> GetPhotos(int id)
        {
            var vUrl = "photos?albumId=" + id;
            var vProcess = await Get<List<PhotoEL>>(vUrl);
            return vProcess;
        }

        public async Task<List<CommentEL>> GetComments(int id)
        {
            var vUrl = "comments?postId=" + id;
            var vProcess = await Get<List<CommentEL>>(vUrl);
            return vProcess;
        }
    }
}
