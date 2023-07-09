using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaoCao.Model;
using BaoCao.View;

namespace BaoCao.Control
{
    class Control_Rapphim
    {
        DataSet ds;

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        SqlDataAdapter da;
        SqlCommandBuilder cb;
        DataTable dt;
        ConnectSQL con = new ConnectSQL();
        // Truy vấn theo bảng
        public DataTable select(string table)
        {
            ds = new DataSet();
            string lenh = "select * from " + table;
            da = new SqlDataAdapter(lenh, con.KetnoiCSDL());
            da.Fill(ds, table);
            dt = ds.Tables[table];
            return dt;
        }
        // Truy vấn nhiều bản
        public DataTable TruyVanTheoBang(string table1, string table2, string key, string dieuKien)
        {
            ds = new DataSet();
            string lenh = "select * from " + table1 + "," + table2 + " where ";
            table1 += "." + key;
            table2 += "." + key;
            lenh += table1 + '=' + table2;
            lenh += " and " + table1 + " = '" + dieuKien + "'";
            da = new SqlDataAdapter(lenh, con.KetnoiCSDL());
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }
        //kiểm tra khóa chính
        public bool kiemTrakeyChinh(string bang, string ma)
        {
            DataRow drCheck = ds.Tables[bang].Rows.Find(ma);
            return (drCheck != null);
        }
        // Thêm nhân viên
        public bool Themnhanvien(Nhanvien nv, string table)
        {
            if (kiemTrakeyChinh(table, nv.MaNV))
                return false;
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = nv.MaNV;
            dr[1] = nv.HotenNV;
            dr[2] = nv.Ngaysinh;
            dr[3] = nv.Phai;
            dr[4] = nv.Luong;
            dr[5] = nv.Diachi;
            dr[6] = nv.MaPBV;
            ds.Tables[table].Rows.Add(dr);
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
            return true;
        }
        // XÓA CHUNG
        public void Delete(string table, string key)
        {
            DataRow dr = ds.Tables[table].Rows.Find(key);
            if (dr != null)
            {
                dr.Delete();
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        // Sửa nhân viên
        public void SuaNV(string bang, string ma, Nhanvien nv)
        {
            DataRow dr = ds.Tables[bang].Rows.Find(ma);
            if (dr != null)
            {
                dr["HOTENNV"] = nv.HotenNV;
                dr["NGAYSINH"] = nv.Ngaysinh;
                dr["PHAI"] = nv.Phai;
                dr["LUONG"] = nv.Luong;
                dr["DIACHI"] = nv.Diachi;
                dr["MAPBV"] = nv.MaPBV;
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, bang);
        }
        // Thêm khách hàng
        public bool Themkhachhang(Khachhang kh, string table)
        {
            if (kiemTrakeyChinh(table, kh.Mave))
                return false;
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = kh.Mave;
            dr[1] = kh.Dayghe;
            dr[2] = kh.Soghe;
            dr[3] = kh.Giave;
            dr[4] = kh.TenKh;
            dr[5] = kh.MaLC;
            ds.Tables[table].Rows.Add(dr);
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
            return true;
        }
        // Sửa khách hàng
        public void SuaKH(string bang, string ma, Khachhang kh)
        {
            DataRow dr = ds.Tables[bang].Rows.Find(ma);
            if (dr != null)
            {
                dr["DAYGHE"] = kh.Dayghe;
                dr["SOGHE"] = kh.Soghe;
                dr["GIAVE"] = kh.Giave;
                dr["TENKH"] = kh.TenKh;
                dr["MALC"] = kh.MaLC;
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, bang);
        }
        // Thêm phim 
        public bool Themphim(Phim p, string table)
        {
            if (kiemTrakeyChinh(table, p.MaLC))
                return false;
            DataRow dr = ds.Tables[table].NewRow();
            dr["MALC"] = p.MaLC;
            dr["TENPHIM"] = p.Tenphim;
            dr["NGAYCHIEU"] = p.Ngaychieu;
            dr["GIOCHIEU"] = p.Giochieu;
            dr["MAPC"] = p.MaPC;
            ds.Tables[table].Rows.Add(dr);
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
            return true;
        }
        // Sửa phim
        public void SuaPhim(string bang, string ma, Phim p)
        {
            DataRow dr = ds.Tables[bang].Rows.Find(ma);
            if (dr != null)
            {
                dr["TENPHIM"] = p.Tenphim;
                dr["NGAYCHIEU"] = p.Ngaychieu;
                dr["GIOCHIEU"] = p.Giochieu;
                dr["MAPC"] = p.MaPC;
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, bang);
        }
        // Thêm chi nhánh
        public bool Themchinhanh(Chinhanh cn, string table)
        {
            if (kiemTrakeyChinh(table, cn.MaPBV))
                return false;
            DataRow dr = ds.Tables[table].NewRow();
            dr["MAPBV"] = cn.MaPBV;
            dr["HINHTHUC"] = cn.Hinhthuc;
            dr["DIADIEMPBV"] = cn.DiadiemPBV;
            ds.Tables[table].Rows.Add(dr);
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
            return true;
        }
        // Sửa chi nhánh
        public void SuaChinhanh(string bang, string ma, Chinhanh cn)
        {
            DataRow dr = ds.Tables[bang].Rows.Find(ma);
            if (dr != null)
            {
                dr["HINHTHUC"] = cn.Hinhthuc;
                dr["DIADIEMPBV"] = cn.DiadiemPBV;
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, bang);
        }
        // Thêm công việc
        public bool Themcongviec(Congviec cv, string table)
        {
            if (kiemTrakeyChinh(table, cv.MaCV))
                return false;
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = cv.MaCV;
            dr[1] = cv.TenCV;
            dr[2] = cv.DiadiemCV;
            dr[3] = cv.MaNV;
            dr[4] = cv.MaPB;
            dr[5] = cv.ThoigianBD;
            ds.Tables[table].Rows.Add(dr);
            cb = new SqlCommandBuilder(da);
            da.Update(ds, table);
            return true;
        }
        //Sửa công việc
        public void Suacongviec(string bang, string ma, Congviec cv)
        {
            DataRow dr = ds.Tables[bang].Rows.Find(ma);
            if (dr != null)
            {
                dr[1] = cv.TenCV;
                dr[2] = cv.DiadiemCV;
                dr[3] = cv.MaNV;
                dr[4] = cv.MaPB;
                dr[5] = cv.ThoigianBD;
            }
            cb = new SqlCommandBuilder(da);
            da.Update(ds, bang);
        }

    }
}