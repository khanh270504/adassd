using BaiKtra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BaiKtra.Controllers
{
    public class HomeController : Controller
    {
		QlgiaiBongDaContext qlban = new QlgiaiBongDaContext();
		private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            var listSP = qlban.Trongtais.AsNoTracking().OrderBy(x => x.TrongTaiId).ToList();
            return View(listSP);
        }
        public IActionResult TrongtaiByTranDauId(string tranDauId)
        {
            var trongtaiList = qlban.TrongtaiTrandaus
                                      .Where(ttd => ttd.TranDauId == tranDauId)
                                      .Select(ttd => ttd.TrongTai)
                                      .ToList();

            return View(trongtaiList);
        }
        public ActionResult LoadTrongtaiByTranDauId(string tranDauId)
        {
            var trongtaiList = qlban.TrongtaiTrandaus
                                      .Where(ttd => ttd.TranDauId == tranDauId)
                                      .Select(ttd => ttd.TrongTai)
                                      .ToList();

            return PartialView("PartialMain", trongtaiList);
        }

        public IActionResult Edit(string trongtaiId)
        {
            ViewBag.TrongTaiId = new SelectList(qlban.Trongtais, "TrongTaiId", "HoVaTen");

			var tt = qlban.Trongtais.Find(trongtaiId);

			return View(tt);
			
        }
        [HttpPost]
		public IActionResult Edit(Trongtai trongtai)
		{
			if (ModelState.IsValid)
			{
				// Đặt trạng thái thực thể thành Modified
				qlban.Entry(trongtai).State = EntityState.Modified;
				qlban.SaveChanges();

				return RedirectToAction("Index"); // Sử dụng RedirectToAction
			}

			// Nếu ModelState không hợp lệ, trả lại View với thông tin đã nhập
			return View(trongtai);
		}

	}
}
