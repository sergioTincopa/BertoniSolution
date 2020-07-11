using BertoniSolution.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BertoniSolution.Client
{
    public interface ISolutionClient
    {
        Task<List<AlbumEL>> GetAlbum();
        Task<List<PhotoEL>> GetPhotos(int id);
        Task<List<CommentEL>> GetComments(int id);
    }
}
