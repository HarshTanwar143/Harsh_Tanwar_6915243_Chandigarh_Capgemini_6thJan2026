using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string error = context.Exception.Message;
            Console.WriteLine($"[ERROR] ❌ Exception caught: {error}");

            context.Result = new ContentResult
            {
                StatusCode = 500,
                ContentType = "text/html",
                Content = $@"
                <html>
                <head>
                    <style>
                        * {{ margin:0; padding:0; box-sizing:border-box; font-family:'Segoe UI',sans-serif; }}
                        body {{
                            min-height:100vh;
                            background:linear-gradient(135deg,#667eea 0%,#764ba2 100%);
                            display:flex; align-items:center; justify-content:center;
                        }}
                        .card {{
                            background:white; border-radius:20px; padding:40px;
                            width:460px; box-shadow:0 20px 60px rgba(0,0,0,0.3); text-align:center;
                        }}
                        .icon {{ font-size:60px; margin-bottom:15px; }}
                        h2 {{ color:#2d3748; font-size:24px; margin-bottom:10px; }}
                        p {{ color:#718096; font-size:14px; margin-bottom:20px; }}
                        .error-box {{
                            background:#fff5f5; border:1px solid #feb2b2; border-radius:10px;
                            padding:12px 16px; color:#c53030; font-size:13px;
                            text-align:left; margin-bottom:25px;
                        }}
                        .btn {{
                            display:inline-block; padding:12px 30px;
                            background:linear-gradient(135deg,#667eea,#764ba2);
                            color:white; border-radius:10px; text-decoration:none;
                            font-weight:600; font-size:15px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='card'>
                        <div class='icon'>⚠️</div>
                        <h2>Something Went Wrong</h2>
                        <p>Don't worry! The error has been caught by our exception filter.</p>
                        <div class='error-box'>🔍 Error: {error}</div>
                        <a class='btn' href='/Product/Index'>🏠 Go Back</a>
                    </div>
                </body>
                </html>"
            };

            context.ExceptionHandled = true;
        }
    }
}