create proc SP_searchBook
@Text varchar(50)
as
	begin 
		select * from BookTbl
		where BTitle like '%' + @Text + '%' OR
			BAuthor like '%' + @Text + '%' or
			BCat like '%' + @Text + '%';
	end
go