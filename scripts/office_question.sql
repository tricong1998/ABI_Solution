USE [abiexam_db]
GO
SET IDENTITY_INSERT [dbo].[office_question] ON 

GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [description], [image]) VALUES (1, N'Mở văn bản', N'Mở văn bản tại đường dẫn', NULL, N'qfile_1.docx', NULL, NULL, NULL)
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [description], [image]) VALUES (2, N'Định dạng', N'Thay đổi font chữ trong đoạn văn thành <b>Arial</b>, cỡ chữ <b>14pt</b>', NULL, N'qfile_2.docx', N'afile_2.docx', NULL, NULL)
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [description], [image]) VALUES (3, N'Định dạng', N'Với bullet trong văn bản, thay đổi thụt đầu dòng (indent) của item <b>2</b>, <b>3</b>, <b>5</b> thành <b>2</b> level; các item còn lại thành 3 level', NULL, N'qfile_3.docx', N'afile_3.docx', NULL, NULL)
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [description], [image]) VALUES (4, N'Định dạng', N'Thiết lập giãn dòng cho toàn bộ văn bản là <b>1.3</b>, khoảng cách giữa đoạn văn <b>1</b> và đoạn văn <b>2</b> là <b>8pt</b>, khoảng cách giữa đoạn văn <b>2</b> và đoạn văn <b>3</b> là <b>12pt</b>', NULL, N'qfile_4.docx', N'afile_4.docx', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[office_question] OFF
GO
