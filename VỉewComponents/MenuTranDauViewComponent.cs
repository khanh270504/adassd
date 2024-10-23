using BaiKtra.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKtra.Components
{
	public class MenuTranDauViewComponent : ViewComponent
	{
		private readonly QlgiaiBongDaContext db;

		public MenuTranDauViewComponent(QlgiaiBongDaContext context)
		{
			this.db = context;
		}
		public IViewComponentResult Invoke()
		{
			var loaiSP = db.Trandaus.OrderBy(x => x.TranDauId).Take(6);
			return View(loaiSP);
		}
	}
}
