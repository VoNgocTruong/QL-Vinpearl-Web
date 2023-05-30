using QL_Vinpearl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_Vinpearl.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		private QL_VinpearlEntities db = new QL_VinpearlEntities();
		// GET: Admin/Login
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Login(LoginAdminModel model)
		{
			// query vào bảng quản lý và check các điều kiện.
			var user = db.QUANLY.SingleOrDefault(ql => ql.email == model.Email);
			if (user == null)
			{
				ModelState.AddModelError("", "Tài khoản không tồn tại!");
			}
			else if (user.matKhau == model.MKhau)
			{
				// tạo session để lưu dữ liệu trong phiên làm việc
				string tenQuanLy = user.tenQL;
				Session.Add("TaiKhoan", model.Email);
				Session.Add("MatKhau", model.MKhau);
				Session.Add("Username", tenQuanLy);
				return RedirectToAction("Index", "Dashboard");
			}
			else if (user.matKhau != model.MKhau)
			{
				ModelState.AddModelError("", "Mật khẩu không hợp lệ!");
			}
			else
			{
				ModelState.AddModelError("", "Thông tin tài khoản không hợp lệ!");
			}
			return View("Index");
		}
		public ActionResult Logout()
		{
			// destroy session
			Session["TaiKhoan"] = null;
			Session["MatKhau"] = null;
			Session["Username"] = null;
			return RedirectToAction("Index", "Login");
		}
	}
}