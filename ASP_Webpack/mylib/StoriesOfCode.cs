using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Webpack.mylib
{
    public static class StoriesOfCode
    {
        public static string Stories()
        {
            return $@"
                <div class=""container-fluid"">
                    <div class=""jumbotron-fluid"">
                        <h1 class=""display-4"">Những câu chuyện của Code</h1>
                        <p class=""lead"">Những câu chuyện đời thường của Code về tình yêu, tình bạn và cả về những kinh nghiệm code, chuyện xin việc </p>
                    </div>
                    <div class=""jumbotron"">
                        <img src=""/images/1.jpeg"" width = ""100%"" height = ""10%"">
                        <h3 class=""display-4"">Chuyện của code - Lại chuyện tình yêu và chuyện kinh nghiệm code</h3>
                        <p class=""lead"">
                        Đa phần dân developer tụi mình là những thanh niên suốt ngày cắm mặt vào code, không thích quan hệ xã giao nên dễ bị FA, ít có gấu.
                        Do vậy, đối với nhiều bạn developer FA, tình iu là cái thứ gì đó mình mong muốn nhưng tìm hoài không có, hoặc chỉ thấy trên Voz hoặc mương 14 chứ chưa từng trải nghiệm bao giờ.
                        Ủa mà, nói đi nói lại thì, tình iu là tình yêu, còn code là code, hai thứ này thế quái nào mà liên quan với nhau cho được???
                        Ấy vậy mà có đấy! Dưới khả năng chém gió siêu phàm của Code Dạo thì mấy cái xô và vài con bug còn liên quan đến nhau, tại sao tình yêu và kinh nghiệm code lại không cơ chứ!
                        Bật mí: Nó sẽ giải thích vì sao có nhiều người làm lâu, kinh nghiệm nhiều nhưng lương cứ mãi lèo tèo, không phát triển được đấy.
                        </p>
                        <hr class=""my-4"">
                        <a class=""btn btn-outline-success btn-lg"" href=""https://toidicodedao.com/2019/01/22/chuyen-tinh-iu-va-kinh-nghiem-code/#more-5939"" role=""button"">Xem thêm</a>
                    </div>
                    <div class=""jumbotron"">
                        <img src=""/images/2.jpg"" width = ""100%"" height = ""10%"">
                        <h3 class=""display-4"">Chuyện của code - Đi xin việc cũng như đi... tán gái</h3>
                        <p class=""lead"">
                        Chẳng là, vào tháng 8, mình sẽ kết thúc chương trình học. Do đó, thời gian gần đây, mình cũng tranh thủ đi nộp CV, phỏng vấn xin việc, tìm một công việc để làm sau khi ra trường 
                        (Quá trình này cũng lắm chuyện bi hài, lần sau mình sẽ chia sẻ hơn trong series Tìm Việc Trời Tây).
                        Xin việc cũng nhiều, phỏng vấn cũng lắm, mình chợt nhận ra rằng có khá nhiều điểm tương đồng đến kì lạ giữa xin việc và… tán gái. Các bạn vừa đọc vừa ngẫm thử xem có đúng không nhé!
                        </p>
                        <hr class=""my-4"">
                        <a class=""btn btn-outline-success btn-lg"" href=""https://toidicodedao.com/2017/07/19/di-xin-viec-va-di-tan-gai/#more-4386"" role=""button"">Xem thêm</a>
                    </div>
                    <div class=""jumbotron"">
                        <img src=""/images/3.jpg"" width = ""100%"" height = ""10%"">
                        <h3 class=""display-4"">Chuyện của code - Từ chuyện con ếch luộc,chuyện tán gái cho tới chuyện chàng lập trình viên</h3>
                        <p class=""lead"">
                        Từ chuyện con ếch luộc</p>
                        <p class=""lead"">Xin bắt đầu bài viết bằng một câu chuyện tưởng chừng nhảm nhí mà lại vô cùng xâu xắc. (Bạn nào không thích đọc truyện thì cứ kéo xuống đọc phần cuối nha).
                        </p>
                        <hr class=""my-4"">
                        <a class=""btn btn-outline-success btn-lg"" href=""https://toidicodedao.com/2017/06/01/ech-tan-gai-va-lap-trinh-vien/#more-4117"" role=""button"">Xem thêm</a>
                    </div>
                    <div class=""jumbotron"">
                        <img src=""/images/4.jpg"" width = ""100%"" height = ""10%"">
                        <h3 class=""display-4"">Chuyện của code - Từ cốc nước đầy đến chuyện học công nghệ và phương cách sống</h3>
                        <p class=""lead"">
                        Chúng ta bắt đầu bài viết hôm nay bằng câu chuyện hư cấu về một chàng coder điển trai tài năng tên H.H.N.N. là một coder tài năng, tốt nghiệp đại học F. danh tiếng. Ngay sau khi ra trường, 
                        N. đã được một công ty lớn F. mời vào làm việc với mức lương ngàn đô. Trong công ty lớn, N được học bài bản về các quy trình làm việc, qui tắc viết code sạch. Chứng tỏ được khả năng của bản 
                        thân, sự nghiệp của N đi lên như diều gặp chó, nhầm, gặp gió.Tuy nhiên, do chán bộ máy làm việc cồng kềnh phức tạp,  N xin nghỉ việc, chuyển sang công ty K. nhỏ hơn làm product để có thể làm 
                        những điều mình thích. Qua công ty mới, N vẫn cứng rắn áp dụng các qui trinh, cách code mình đã làm việc ở công ty cũ. Khi nghe đồng đội phàn nàn, N vẫn cứng đầu bảo thủ không thay đổi, cho 
                        rằng cách của mình là đúng nhất. Dần đà, dù có tài nhưng N nói ko ai nghe, còn bị team xa lánh.
                        </p>
                        <hr class=""my-4"">
                        <a class=""btn btn-outline-success btn-lg"" href=""https://toidicodedao.com/2017/03/09/coc-nuoc-day-va-chuyen-hoc-cong-nghe/#more-3802"" role=""button"">Xem thêm</a>
                    </div>
                    <div class=""jumbotron"">
                        <img src=""/images/5.jpg"" width = ""100%"" height = ""10%"">
                        <h3 class=""display-4"">Chuyện của code - Từ tối ưu code đến optimize cuộc sống</h3>
                        <p class=""lead"">
                        Với một người có tâm hồn bay bổng và đầu óc sáng tạo như tác giả blog Code dạo (là mình) thì cái thứ quái gì cũng có thể biến thành bài viết được.
                        Hôm nay khi mình đang ngồi đọc sách dưới tán cây thì bỗng… một quả sầu riêng nặng nửa kg rơi trúng đầu. Nhờ vậy mà mình mới nảy ra cảm hứng viết series này. Tên đầy đủ của series là Từ Chuyện 
                        Code Ngẫm Chuyện Đời, do hơi dài nên mình rút gọn lại thành Chuyện Code Chuyện Đời cho dễ đọc dễ nhớ!
                        Trong quá trình học và đi làm, đôi khi ta học được nhiều kĩ thuật lập trình, thuật toán và các nguyên lý rất hay ho. Khi quả sầu riêng rơi vào đầu, mình chợt ngộ ra rằng: những kĩ thuật cũng 
                        như nguyên lý này không chỉ áp dụng được trong code mà còn có thể áp dụng vào đời sống.
                        Series Chuyện Code Chuyện Đời ra đời từ đó. Bài viết đầu tiên trong series sẽ nói về chuyện optimize (tối ưu hoá) code và optimize cuộc sống.
                        </p>
                        <hr class=""my-4"">
                        <a class=""btn btn-outline-success btn-lg"" href=""https://toidicodedao.com/2017/02/23/optimize-code-va-cuoc-song/#more-3762"" role=""button"">Xem thêm</a>
                    </div>
                </div>
            ";
        }
    }
}
