using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiKtra.Models;

public partial class Trongtai
{
    public string TrongTaiId { get; set; } = null!;

    public string? HoVaTen { get; set; }

    public DateOnly? NgaySinh { get; set; }
	[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Quê hương chỉ được nhập chữ.")]
	public string? QueHuong { get; set; }

    public string? QuocTich { get; set; }

    public int? SoNamKinhNghiem { get; set; }
	//[RegularExpression(@".*\.png$", ErrorMessage = "File ảnh phải có định dạng .png.")]
	public string? Anh { get; set; }

    public virtual ICollection<TrongtaiTrandau> TrongtaiTrandaus { get; set; } = new List<TrongtaiTrandau>();
}
