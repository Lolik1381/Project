#pragma checksum "C:\Users\Honor\source\repos\AP\Project\Views\Home\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6906c60079fa9af758bdafcc3b429c260b5d451b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_index), @"mvc.1.0.view", @"/Views/Home/index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Honor\source\repos\AP\Project\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Honor\source\repos\AP\Project\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6906c60079fa9af758bdafcc3b429c260b5d451b", @"/Views/Home/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e31fbbec8fb4222cf117a26f28137c5b00e63f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("runat", new global::Microsoft.AspNetCore.Html.HtmlString("server"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6906c60079fa9af758bdafcc3b429c260b5d451b3549", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

    <script language=""C#"" runat=""server"">

		 void SubmitBtn_Click(Object sender, EventArgs e)
		{
			 Message.Text=""Hello World!!"";
		}

    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6906c60079fa9af758bdafcc3b429c260b5d451b4877", async() => {
                WriteLiteral(@"
		<div class=""header"">
			<div class=""note"">
				<div class=""wrapper"">
					<a href=""#"" class=""close"">☓</a>
					<p>ПРИМЕЧАНИЕ ДЛЯ ПУТЕШЕСТВЕННИКОВ.<a href=""https://www.tripadvisor.ru/Articles-l297-COVID_2019.html"">Что нужно знать о пандемии COVID‑19</a></p>
				</div>
			</div>
			<div class=""header-login"">
				<div class=""wrapper"">
					<div class=""conteiner"">
						<img src=""img/TRIP.png""");
                BeginWriteAttribute("alt", " alt=\"", 750, "\"", 756, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""logo"">
						<a href=""#popup"" class=""nav_1"">Войти</a>
						<a href=""#"" class=""nav_2"">Опубликовать</a>
						<!--<a href=""#"" class=""nav_3"">Уведомления</a>
						<a href=""#"" class=""nav_4"">Поездки</a>-->
					</div>

					<div class=""foto_preview"">
						<div class=""conteiner_p"">
							<p>Отправляйся в путешествие прямо сейчас!</p>
						</div>

						<img src=""img/header_foto.jpeg""");
                BeginWriteAttribute("alt", " alt=\"", 1161, "\"", 1167, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""600"" class=""preview_foto"">
					</div>
				</div>
			</div>
		</div>


		<div class=""content"">
			<div class=""wrapper"">
				<p>Направления, которые любят путешественники</p>

				<div class=""slider middle"">
					<div class=""slides"">
						<input type=""radio"" name=""r"" id=""r1"" checked>
						<input type=""radio"" name=""r"" id=""r2"">
						<input type=""radio"" name=""r"" id=""r3"">
						<input type=""radio"" name=""r"" id=""r4"">

						<a href=""#"" class=""slide s1""><img src=""img/caption (1).jpg""");
                BeginWriteAttribute("alt", " alt=\"", 1677, "\"", 1683, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/caption.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 1762, "\"", 1768, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/caption (5).jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 1851, "\"", 1857, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/caption (3).jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 1940, "\"", 1946, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/vail.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 2022, "\"", 2028, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/italy.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 2105, "\"", 2111, 0);
                EndWriteAttribute();
                WriteLiteral(" height=\"150\"></a>\r\n\t\t\t\t\t\t<a href=\"#\" class=\"slide\"><img src=\"img/caption (7).jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 2194, "\"", 2200, 0);
                EndWriteAttribute();
                WriteLiteral(@" height=""150""></a>
					</div>

					<div class=""navigation"">
						<label for=""r1"" class=""bar""></label>
						<label for=""r2"" class=""bar""></label>
						<label for=""r3"" class=""bar""></label>
						<label for=""r4"" class=""bar""></label>
					</div>
				</div>

			</div>
		</div>
		<div class=""footer""></div>

		<div id=""popup"" class=""popup"">
			<a href=""#"" class=""popup_area""></a>
			<div class=""popup_body"">
				<div class=""popup_content"">
					<a href=""#"" class=""popup_close"">X</a>
					<div class=""popup_title"">Модальное окно №1</div>
					<div class=""popup_text"">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Aspernatur minima libero illo quam molestiae distinctio, atque possimus, reiciendis, ab harum a. Et accusamus, in error eum magni atque, illo tempore!</div>
				</div>
			</div>
		</div>
	");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
