namespace LTQL_BTL04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHD",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 20),
                        MaMH = c.String(nullable: false, maxLength: 20),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Single(nullable: false),
                        GiamGia = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaMH })
                .ForeignKey("dbo.HoaDon", t => t.MaHD, cascadeDelete: true)
                .ForeignKey("dbo.MatHang", t => t.MaMH, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaMH);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 20),
                        MaKH = c.String(maxLength: 10),
                        MaNV = c.String(maxLength: 20),
                        NgayLapHD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 10),
                        TenKH = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 100),
                        DienThoai = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false),
                        Role = c.String(),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 20),
                        TenNV = c.String(nullable: false),
                        SoDienThoai = c.String(nullable: false, maxLength: 11),
                        DiaChi = c.String(nullable: false),
                        NSinh = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.MatHang",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 20),
                        TenMH = c.String(nullable: false),
                        DonGia = c.Single(nullable: false),
                        HinhAnh = c.String(),
                        TenLoaiMH = c.String(),
                        LoaiHang_MaLoai = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MaMH)
                .ForeignKey("dbo.LoaiHang", t => t.LoaiHang_MaLoai)
                .Index(t => t.LoaiHang_MaLoai);
            
            CreateTable(
                "dbo.LoaiHang",
                c => new
                    {
                        MaLoai = c.String(nullable: false, maxLength: 5),
                        TenLoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatHang", "LoaiHang_MaLoai", "dbo.LoaiHang");
            DropForeignKey("dbo.CTHD", "MaMH", "dbo.MatHang");
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.CTHD", "MaHD", "dbo.HoaDon");
            DropIndex("dbo.MatHang", new[] { "LoaiHang_MaLoai" });
            DropIndex("dbo.HoaDon", new[] { "MaNV" });
            DropIndex("dbo.HoaDon", new[] { "MaKH" });
            DropIndex("dbo.CTHD", new[] { "MaMH" });
            DropIndex("dbo.CTHD", new[] { "MaHD" });
            DropTable("dbo.LoaiHang");
            DropTable("dbo.MatHang");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CTHD");
        }
    }
}
