using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyShopBanQuatDien.Entities;
using QuanLyShopBanQuatDien.Pages.Utils;
using QuanLyShopBanQuatDien.DTO;
using QuanLyShopBanQuatDien.DAO;

namespace QuanLyShopBanQuatDien.Service
{
    public class GRNService
    {
        public static List<GRNEntity> findAll()
        {
            return GRNDAO.findAll();
        }

        public static List<GRNEntity> findByCodeWithWildCard(string code)
        {
            return GRNDAO.findByCodeWithWildCard(code);
        }


        public static GRNEntity findByCode(string code)
        {
            List<GRNEntity> grns = GRNDAO.findByCode(code);
            if (DataUtils.isEmpty(grns))
            {
                return null;
            }

            GRNEntity grn = grns[0];

            List<GRNDetailEntity> grnDetails = GRNDetailDAO.findByGRNCode(code);
            grn.grnDetails = grnDetails;

            return grn;
        }

        public static ResponseObject<GRNEntity> create(GRNEntity grn)
        {
            ResponseObject<GRNEntity> res = new ResponseObject<GRNEntity>();
            res.isSuccess = false;

            if (GRNDAO.checkExist(grn.code))
            {
                res.errorMessage = "Mã phiếu nhập đã tồn tại";
                return res;
            }

            foreach (GRNDetailEntity grnDetail in grn.grnDetails)
            {
                grn.totalAmount += grnDetail.subtotal;
            }

            if (!GRNDAO.create(grn))
            {
                res.errorMessage = "Không thể tạo phiếu nhập";
                return res;
            }

            foreach (GRNDetailEntity grnDetail in grn.grnDetails)
            {
                grnDetail.grn = grn;
                GRNDetailDAO.create(grnDetail);
            }

            res.isSuccess = true;
            return res;
        }

        public static ResponseObject<GRNEntity> update(GRNEntity grn)
        {
            ResponseObject<GRNEntity> res = new ResponseObject<GRNEntity>();
            res.isSuccess = false;

            if (!GRNDAO.checkExist(grn.code))
            {
                res.errorMessage = "Mã phiếu nhập không tồn tại";
                return res;
            }

            grn.totalAmount = 0;

            foreach (GRNDetailEntity grnDetail in grn.grnDetails)
            {
                grn.totalAmount += grnDetail.subtotal;
            }

            if (!GRNDAO.update(grn))
            {
                res.errorMessage = "Không thể cập nhật phiếu nhập";
                return res;
            }

            GRNDetailDAO.deleteByGRNCode(grn.code);

            foreach (GRNDetailEntity grnDetail in grn.grnDetails)
            {
                grnDetail.grn = grn;
                GRNDetailDAO.create(grnDetail);
            }

            res.isSuccess = true;
            return res;
        }

        public static ResponseObject<GRNEntity> delete(string code)
        {
            ResponseObject<GRNEntity> res = new ResponseObject<GRNEntity>();
            res.isSuccess = false;

            if (!GRNDAO.checkExist(code))
            {
                res.errorMessage = "Mã phiếu nhập không tồn tại";
                return res;
            }

            if (!GRNDAO.delete(code))
            {
                res.errorMessage = "Không thể xóa phiếu nhập";
                return res;
            }

            res.isSuccess = true;
            return res;
        }
    }
}