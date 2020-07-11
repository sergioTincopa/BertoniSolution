using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BertoniSolution.Client;
using BertoniSolution.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BertoniSolution.Web.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IConfiguration Configuration;
        private readonly ISolutionClient SolutionClient;

        public SolutionController(IConfiguration IConfiguration, ISolutionClient ISolutionClient)
        {
            Configuration = IConfiguration;
            SolutionClient = ISolutionClient;
        }

        public async Task<IActionResult> GetAlbums()
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await SolutionClient.GetAlbum();
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Json(Response);
        }

        public async Task<IActionResult> GetPhotos(int id)
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await SolutionClient.GetPhotos(id);
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Json(Response);
        }

        public async Task<IActionResult> GetComments(int id)
        {
            ResponseModel Response = new ResponseModel();

            try
            {
                Response.Result = await SolutionClient.GetComments(id);
            }
            catch (Exception ex)
            {
                Response.ExceptionMessage = ex.Message;
            }

            return Json(Response);
        }
    }
}
