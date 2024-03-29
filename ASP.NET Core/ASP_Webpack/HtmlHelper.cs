﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text;

public static class HtmlHelper
{
    /// <summary>
    /// Phát sinh trang HTML
    /// </summary>
    /// <param name="title">Tiêu đề trang</param>
    /// <param name="content">Nội dung trong thẻ body</param>
    /// <returns>Trang HTML</returns>
    public static string HtmlDocument(string title, string content)
    {
        return $@"
                    <!DOCTYPE html>
                    <html>
                        <head>
                            <meta charset=""UTF-8"">
                            <title>{title}</title>
                            <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                            <script src=""/js/jquery.min.js"">
                            </script><script src=""/js/popper.min.js"">
                            </script><script src=""/js/bootstrap.min.js""></script>
                        </head>
                        <body>
                            {content}
                        </body>
                    </html>";
    }


    /// <summary>
    /// Phát sinh HTML thanh menu trên, menu nào  active phụ thuộc vào URL mà request gủi đến
    /// </summary>
    /// <param name="menus">Mảng các menu item, mỗi item có cấu trúc {url, lable}</param>
    /// <param name="request">HttpRequest</param>
    /// <returns></returns>

    public static string MenuTop(object[] menus, HttpRequest request)
    {

        var menubuilder = new StringBuilder();
        menubuilder.Append("<ul class=\"navbar-nav\">");
        foreach (dynamic menu in menus)
        {
            string _class = "nav-item";
            // Active khi request.PathBase giống url của menu
            if (request.Path == menu.url) _class += " active";
            menubuilder.Append($@"
                                <li class=""{_class}"">
                                    <a class=""nav-link"" href=""{menu.url}"">{menu.label}</a>
                                </li>
                                ");
        }
        menubuilder.Append("</ul>\n");

        string menuhtml = $@"
                    <div class=""container"">
                        <nav class=""navbar navbar-expand-lg navbar-dark bg-success"">
                            <a class=""navbar-brand"" href=""/""><b>UYEN'S BLOG</b></a>
                            <button class=""navbar-toggler"" type=""button""
                                data-toggle=""collapse"" data-target=""#my-nav-bar""
                                aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                                {menubuilder}
                            </div>
                    </nav></div>";

        return menuhtml;
    }

    /// <summary>
    /// Những menu item mặc định cho trang
    /// </summary>
    /// <returns>Mảng các menuitem</returns>
    public static object[] DefaultMenuTopItems()
    {
        return new object[] {

              new {
                  url = "/",
                  label = "Trang chủ"
              },
              new {
                  url = "/code-stories",
                  label = "Chuyện của Code"
              },
              new {
                  url = "/posts",
                  label = "Bài viết"
              }
              ,
              new {
                  url = "/about",
                  label = "Giới thiệu"
              },
              new {
                  url = "/coding",
                  label = "Nghề coding"
              },
              new {
                  url = "/moment",
                  label = "Khoảnh khắc"
              }
          };
    }


    // Mở rộng String, phát sinh thẻ HTML với nội dụng là String
    // Ví dụ: 
    // "content".HtmlTag() => <p>content</p>
    // "content".HtmlTag("div", "text-danger") => <div class="text-danger">content</div>
    public static string HtmlTag(this string content, string tag = "p", string _class = null)
    {
        string cls = (_class != null) ? $" class=\"{_class}\"" : null;
        return $"<{tag + cls}>{content}</{tag}>";
    }
    public static string td(this string content, string _class = null)
    {
        return content.HtmlTag("td", _class);
    }
    public static string tr(this string content, string _class = null)
    {
        return content.HtmlTag("tr", _class);
    }
    public static string table(this string content, string _class = null)
    {
        return content.HtmlTag("table", _class);
    }


}