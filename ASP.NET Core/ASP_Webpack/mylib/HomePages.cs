using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Webpack.mylib
{
    public static class HomePages
    {
        public static string HtmlTrangchu()
        {
            return $@"
            <div class=""container-fluid"">
                <div class=""jumbotron-fluid"">
                    <h4 class=""display-4"">Chào mừng mọi người đã đến với chiếc Blog của Uyên Nguyễn</h4>
                    <p class=""lead"">Nơi lan tỏa niềm vui và thể hiện niềm đam mê với những dòng code. Đừng làm cho việc viết code trở thành một áp lực, hãy biến nó trở thành một niềm đam mê của bạn.
                    Bạn có thể ghé thăm github của tôi <a target=""_blank""
                        href=""https://github.com/uyennguyen0721"">
                        tại đây</a>
                
                    </p>
                    <hr class=""my-4"">
                    <p><b>Developer</b> là một công việc đòi hỏi sự tư duy, cẩn thận và một niềm đam mê mãnh liệt...</p>
                    <a class=""btn btn-success btn-lg"" href=""https://toidicodedao.com/2018/11/29/lam-sao-de-co-dam-me-lap-trinh/"" role=""button"">Xem thêm</a>
                </div>
            </div>
         ";

        }
    }
}
