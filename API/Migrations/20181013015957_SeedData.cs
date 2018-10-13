using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Categories] ON 

            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Sneakers')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Fruits')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Courses')
            INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1004, N'Dairy')
            SET IDENTITY_INSERT [dbo].[Categories] OFF
            SET IDENTITY_INSERT [dbo].[Fields] ON 

            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (6, 4, N'Color')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (7, 5, N'Calories per 100g')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (8, 5, N'Taste')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (9, 6, N'Proffesional field')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (10, 6, N'On sale')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (11, 6, N'Instructor name')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (12, 6, N'Duration')
            INSERT [dbo].[Fields] ([Id], [CategoryId], [Name]) VALUES (1006, 1004, N'Calories')
            SET IDENTITY_INSERT [dbo].[Fields] OFF
            SET IDENTITY_INSERT [dbo].[Products] ON 

            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (6, 5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://www.theorganicplace.com.au/wp-content/uploads/2015/01/Organic-Bananas.jpg', N'Bananas', 3)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (7, 5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://5.imimg.com/data5/YY/EN/MY-8155364/fresh-apple-500x500.jpg', N'Apple', 2.99)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (8, 5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://static.seattletimes.com/wp-content/uploads/2017/07/7b4c85c2-6687-11e7-8665-356bf84600f6-780x520.jpg', N'Watermelon', 4)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (9, 5, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://pull01-thefruitcompany.netdna-ssl.com/media/catalog/product/cache/1/image/800x/9df78eab33525d08d6e5fb8d27136e95/b/a/bartlett-pears_4.jpg', N'Pear', 2.11)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (10, 4, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://assets.adidas.com/images/w_840,h_840,f_auto,q_auto,fl_lossy/cf8211db4aab4cac9494a92a008d402d_9366/Ultraboost_Shoes_Black_CM8110_01_standard.jpg', N'ULTRABOOST SHOES', 130)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (11, 4, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://assets.adidas.com/images/w_840,h_840,f_auto,q_auto,fl_lossy/232e0a96c858412bbcd8a9140082d8f2_9366/NMD_R1_Shoes_Black_B37618_01_standard.jpg', N'NMD_R1 SHOES', 150)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (12, 4, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://assets.adidas.com/images/w_840,h_840,f_auto,q_auto,fl_lossy/a33f4a218d9043879851a8e90100316c_9366/Ultraboost_Shoes_Blue_CM8113_01_standard.jpg', N'ULTRABOOST SHOES', 180)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (13, 6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://udemy-images.udemy.com/course/750x422/684824_3626_2.jpg', N'Ultimate Spring 5 Course', 11.49)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (1006, 6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://irensaltali.com/en/content/images/2018/02/asp-net-core-mvc.jpg', N'ASP.NET MVC Core Course', 16.99)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (1007, 6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://resources.cloud.genuitec.com/wp-content/uploads/2017/04/angular4-icon.png', N'Angular 4 Course', 14.49)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (1008, 1004, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://www.uq.edu.au/news/sites/uqnews.drupal.uq.edu.au/files/styles/square/http/uqnews.drupal.uq.edu.au/filething/get/84456/Cheeseweb.jpg%3Fitok%3DK7S-mmF2', N'Dairy', 33)
            INSERT [dbo].[Products] ([Id], [CategoryId], [Description], [ImageUrl], [Name], [Price]) VALUES (1009, 6, N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'https://udemy-images.udemy.com/course/750x422/88750_c444_7.jpg', N'Advanced C#', 10)
            SET IDENTITY_INSERT [dbo].[Products] OFF
            SET IDENTITY_INSERT [dbo].[FieldValues] ON 

            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (9, 7, 7, N'130 kcal')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (10, 8, 7, N'Sour')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (11, 7, 8, N'30 kcal')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (12, 8, 8, N'Sweet')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (13, 7, 9, N'80 kcal')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (14, 8, 9, N'Sweet')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (15, 6, 10, N'Gray-black')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (16, 6, 11, N'Black')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (17, 6, 12, N'Blue')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (18, 9, 13, N'Programming')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (19, 10, 13, N'Yes')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (20, 11, 13, N'John Smith')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (21, 12, 13, N'14 hours')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1007, 9, 1006, N'Programming')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1008, 10, 1006, N'Yes')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1009, 11, 1006, N'John Smith')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1010, 12, 1006, N'18 hours')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1011, 9, 1007, N'Programming')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1012, 10, 1007, N'No')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1013, 11, 1007, N'Karl Gog')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1014, 12, 1007, N'20.5 hours')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1015, 1006, 1008, N'200 kcal')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1016, 9, 1009, N'Programming')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1017, 10, 1009, N'Yes')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1018, 11, 1009, N'Karl Gog')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1019, 12, 1009, N'10 hours')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1020, 7, 6, N'130 kcal')
            INSERT [dbo].[FieldValues] ([Id], [FieldId], [ProductId], [Value]) VALUES (1021, 8, 6, N'Sweet')
            SET IDENTITY_INSERT [dbo].[FieldValues] OFF

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
