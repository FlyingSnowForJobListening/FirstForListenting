USE [OrderCenter_Customs]
GO

/****** Object:  StoredProcedure [dbo].[MessageCenterQuery]    Script Date: 9/11/2015 9:30:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[MessageCenterQuery]
 @OperateFlag int,
 @OrderNo nvarchar(50),
 @LogisticsNo nvarchar(50)
as
begin
	SET XACT_ABORT ON;
	begin tran
	if @OperateFlag = 301
		begin
			if not exists(select * from dbo.OC_CustomsReturn where orderNo = @OrderNo)
				begin
					insert into dbo.OC_CustomsReturn (
						order_Id,
						orderNo,
						logisticsId,
						logisticsNo,
						orderNoFake
					) select orderId, orderNo, logistics_Id,logisticsNo,customs_OrderNo  from dbo.OC_Orders
						where orderNo = @OrderNo;
					update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule='created_301';
				end
			else
				begin
					DECLARE	@fakeNo nvarchar(50);
					set @fakeNo = (select customs_OrderNo from dbo.OC_Orders where orderNo = @OrderNo);
					update dbo.OC_CustomsReturn set
						copNo_602 = null,
						preNo_602 = null,
						status_302 = null,
						status_501 = null,
						status_602 = null,
						lastUpdateTime = GETDATE(),
						schedule = 'create_301',
						logisticsRL = null,
						orderNoFake = @fakeNo
						where orderNo = @OrderNo;
				end
			--select * from dbo.OC_Orders o
			select b.appUid,b.appUname,orderNo,customs_OrderNo,o.logisticsNo,ebpCode,ebpName,orderFreight,orderFreightCurrency,consignee,consigneeAddress,consigneeTelephone,consigneeCountry,consigneeCountry_Code,orderAmount,
			itemNo,gg.gnoCode,gCode,gName,gModel,barCode,brand,unit1,goodsCurrency,goddsNum,price,totalAmount from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id = l.logisticsId
			inner join dbo.OC_Shops s on s.shopId = o.shop_Id
			inner join dbo.OC_Business b on b.businesId = s.busines_Id
			inner join dbo.OC_Order_Goods og on og.order_Id = o.orderId
		    inner join dbo.OC_Goods_GnoCode gg on b.tradeCode = gg.tradeCode
			where orderNo = @OrderNo and og.gnoCode=gg.gnoCode
			--where orderNo ='68476157778695' 
			
		end
	else if @OperateFlag = 501
		begin
			--select * from dbo.OC_Orders o
			select customsCode,l.appUid,l.appUname,orderNo,customs_OrderNo,customs_OrderNo,ebpCode,ebpName,logisticsCode,logisticsName,logisticsNo,ieFlag,trafMode,trafName,voyageNo,orderFreight,insuredFee,loginticsFreight,
			logisticsFreightCurrency,orderWeight,orderNetWeight,packNo,consignee,consigneeAddress,consigneeTelephone,consigneeCountry,consigneeCountry_Code,shipper,shipperAddress,shipperTelephone
		    from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id = l.logisticsId
			inner join dbo.OC_Shops s on s.shopId = o.shop_Id
			inner join dbo.OC_Business b on b.businesId = s.busines_Id
			where o.customs_OrderNo = @OrderNo;
			--where orderNo = 'TBB-980206715';
		end
	else if @OperateFlag = 5031
		begin
			select customsCode, appType, l.appUid, l.appUname, logisticsCode, logisticsName, o.logisticsNo,ieFlag, trafMode, trafName, voyageNo, billNo,logisticsRL from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id = l.logisticsId
			inner join dbo.OC_Shops s on s.shopId = o.shop_Id
			inner join dbo.OC_Business b on b.businesId = s.busines_Id
			inner join dbo.OC_CustomsReturn c on c.order_Id = o.orderId
			where o.logisticsNo = @LogisticsNo
			--where o.logisticsNo = 'RM804832292CN';
		end
	else if @OperateFlag = 5032
		begin
			select customsCode, appType, l.appUid, l.appUname, logisticsCode, logisticsName, o.logisticsNo,ieFlag, trafMode, trafName, voyageNo, billNo,logisticsRL from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id = l.logisticsId
			inner join dbo.OC_Shops s on s.shopId = o.shop_Id
			inner join dbo.OC_Business b on b.businesId = s.busines_Id
			inner join dbo.OC_CustomsReturn c on c.order_Id = o.orderId
			where o.customs_OrderNo = @OrderNo;
			--where o.logisticsNo = 'RM804832292CN';
		end
	else if @OperateFlag = 601
		begin
			--select * from dbo.OC_Orders o
			select customsCode,b.appUid,b.appUname,orderNo,customs_OrderNo,ebpCode,ebpName,logisticsNo,logisticsCode,logisticsName,ieFlag,portCode,b.tradeCode,tradeName,agentCode,agentName,tradeMode,trafMode,
			trafName,voyageNo,billNo,destinationCountry,destinationPort,loginticsFreight,logisticsFreightCurrency,insuredFee,insuredFeeCurrency,wrapType,packNo,orderWeight,orderNetWeight,
			itemNo,gg.gnoCode,gCode,gName,gModel,barCode,goodsCountryCode,goodsCurrency,unit1,unit2,goddsNum,price,totalAmount
			 from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id = l.logisticsId
			inner join dbo.OC_Shops s on s.shopId = o.shop_Id
			inner join dbo.OC_Business b on b.businesId = s.busines_Id
			inner join dbo.OC_Order_Goods og on og.order_Id = o.orderId
			inner join dbo.OC_Goods_GnoCode gg on b.tradeCode = gg.tradeCode
			where o.logisticsNo = @LogisticsNo and og.gnoCode=gg.gnoCode
			--where o.logisticsNo = 'RM804832292CN';
		end
	else if @OperateFlag = 1000
		begin
			select o.orderNo, l.logisticsType from dbo.OC_Orders o
			inner join dbo.OC_Logistic l on o.logistics_Id=l.logisticsId
			where o.logisticsNo= @LogisticsNo
		end
 if @@ERROR <>0
  begin
  rollback tran;
  end
 else
  commit tran;
end








GO


