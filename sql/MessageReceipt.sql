USE [OrderCenter_Customs]
GO

/****** Object:  StoredProcedure [dbo].[MessageReceipt]    Script Date: 9/11/2015 9:31:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MessageReceipt] 
 @OperateFlag int,
 @OrderNo varchar(20),
 @Logistics varchar(20),
 @Status int,
 @ReturnInfo nvarchar(200),
 @CopNo varchar(20),
 @PreNo varchar(20),
 @BillNo varchar(50),
 @Comment1 varchar(300),
 @Comment2 varchar(300),
 @Comment3 varchar(300),
 @Comment4 varchar(300),
 @Comment5 varchar(300)
AS
begin
	SET XACT_ABORT ON;
	begin tran
	DECLARE	@returnvalue int
	if @OperateFlag = 302
		begin
		if exists (select * from dbo.OC_CustomsReturn where orderNoFake = @OrderNo)
			begin
				update dbo.OC_CustomsReturn set
					status_302 = @Status,
					returnInfo = @ReturnInfo,
					lastUpdateTime = GETDATE(),
					schedule='received_302'
					--select * from dbo.OC_CustomsReturn
					where orderNoFake=@OrderNo and (status_302 is null or (status_302 < @Status and status_302 !=100) or @Status = 100); 
			end
		else
			begin
				insert into dbo.OC_CustomsReturn (
							order_Id,
							orderNo,
							logisticsId,
							logisticsNo,
							orderNoFake
						) select orderId, orderNo, logistics_Id,logisticsNo,customs_OrderNo from dbo.OC_Orders
							where customs_OrderNo = @OrderNo;
				update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule='received_302', status_302 = @Status, returnInfo=@ReturnInfo where orderNo = @OrderNo;
			end
		end
	else if @OperateFlag = 501
		begin
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule = 'created_501' where orderNoFake = @OrderNo;
			update dbo.OC_Orders set orderFreight = CONVERT(money, @CopNo), orderWeight = CONVERT(float,@ReturnInfo), billNo = @BillNo where customs_OrderNo = @OrderNo;
		end
	else if @OperateFlag = 5011
		begin
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule = 'created_501' where logisticsNo = @Logistics;
			update dbo.OC_Orders set billNo = @BillNo where logisticsNo = @Logistics;
		end
	else if @OperateFlag = 502
		begin
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule ='received_502', status_501= @Status,returnInfo=@ReturnInfo,logisticsRL='R' where logisticsNo = @Logistics;
		end
	else if @OperateFlag = 5031
		begin
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule = 'created_503' where logisticsNo = @Logistics;
		end
	else if @OperateFlag = 5032
		begin
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule = 'created_503' where orderNo = @OrderNo;
		end
	else if @OperateFlag = 601
		begin 
			update dbo.OC_CustomsReturn set lastUpdateTime = GETDATE(), schedule = 'created_601', copNo_602 = @CopNo where orderNoFake = @OrderNo;
		end
	else if @OperateFlag = 602
		begin
		if exists(select status_602 from dbo.OC_CustomsReturn where copNo_602 = @CopNo)
			begin
			set	@returnvalue = (select status_602 from dbo.OC_CustomsReturn where copNo_602 = @CopNo);
			if @Status = 800
				begin
					update dbo.OC_CustomsReturn set
					status_602 =  @Status,
					preNo_602 = @PreNo,
					lastUpdateTime = GETDATE(), schedule = 'received_602',
					returnInfo=@ReturnInfo,logisticsRL='L'
					where copNo_602 = @CopNo
					update dbo.OC_Orders set 
					orderState = 5
					where orderNo = (select orderNo from dbo.OC_CustomsReturn where copNo_602 = @CopNo)
				end
			else if @Status =100 or (@returnvalue is null or @returnvalue < @Status)
				begin
					update dbo.OC_CustomsReturn set
					status_602 =  @Status,
					preNo_602 = @PreNo,
					lastUpdateTime = GETDATE(), schedule = 'received_602',
					returnInfo=@ReturnInfo
					where copNo_602 = @CopNo
				end
			end
		end
 if @@ERROR <>0
  begin
  rollback tran;
  end
 else
  commit tran;
end





GO


