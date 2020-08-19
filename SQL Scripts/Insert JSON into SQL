
go

declare @Json nvarchar(max) 
set @Json = N'[
{"BOARD": "A", "BOARD_TITLE": "Test", "LATEST_COLLECTED_DATE": "2020-08-06 19:32:15.340"},
{"BOARD": "B", "BOARD_TITLE": "Test2", "LATEST_COLLECTED_DATE": "2020-08-06 19:32:15.340"}
]'

select * from
OPENJSON(@Json)
with (
	Board nvarchar(255) '$.BOARD',
	BOARD_TITLE nvarchar(255) '$.BOARD_TITLE',
	LATEST_COLLECTED_DATE datetime2(7) '$.LATEST_COLLECTED_DATE'
)



--Doing it as a merge:

	select * into #S 
	from OPENJSON(@Json)
	with (
		Board nvarchar(255) '$.BOARD',
		BOARD_TITLE nvarchar(255) '$.BOARD_TITLE',
		LATEST_COLLECTED_DATE datetime2(7) '$.LATEST_COLLECTED_DATE'		
	)

	MERGE [dbo].[FOURCHAN_STATE] AS t
	USING #S AS s
		ON (s.BOARD = t.[BOARD])
	WHEN MATCHED THEN
		UPDATE
			set
			 [BOARD_TITLE] = s.[BOARD_TITLE],
			 [HAS_RUN] = 1,
			 [LATEST_COLLECTED_DATE] = s.[LATEST_COLLECTED_DATE],
			 [LAST_RUN_DATE] = GetDate()
	WHEN NOT MATCHED THEN
		INSERT ([BOARD], [BOARD_TITLE], [HAS_RUN], [LATEST_COLLECTED_DATE], [LAST_RUN_DATE])
		VALUES (s.[BOARD], s.[BOARD_TITLE], 1, s.[LATEST_COLLECTED_DATE], GetDate());
