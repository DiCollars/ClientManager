#pragma checksum "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\Home\UpdateUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24d0e8accd62aab58719d2df86d41fd9332361cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UpdateUser), @"mvc.1.0.view", @"/Views/Home/UpdateUser.cshtml")]
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
#line 1 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\_ViewImports.cshtml"
using ClientManagerMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\_ViewImports.cshtml"
using ClientManagerMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d0e8accd62aab58719d2df86d41fd9332361cf", @"/Views/Home/UpdateUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac05eaf7d07f420c78583813218ee5803145edf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UpdateUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClientManagerMVC.JsonModels.UserJson>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\Home\UpdateUser.cshtml"
  
    ViewData["Title"] = "Update user";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24d0e8accd62aab58719d2df86d41fd9332361cf3509", async() => {
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <input type=\"text\" class=\"form-control\" placeholder=\"Enter name\" name=\"Name\"");
                BeginWriteAttribute("value", " value=\"", 214, "\"", 233, 1);
#nullable restore
#line 7 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\Home\UpdateUser.cshtml"
WriteAttributeValue("", 222, Model.Name, 222, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <input type=\"text\" class=\"form-control\" placeholder=\"Enter last name\" name=\"LastName\"");
                BeginWriteAttribute("value", " value=\"", 372, "\"", 395, 1);
#nullable restore
#line 10 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\Home\UpdateUser.cshtml"
WriteAttributeValue("", 380, Model.LastName, 380, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <input type=\"email\" class=\"form-control\" placeholder=\"Enter email\" name=\"Email\"");
                BeginWriteAttribute("value", " value=\"", 528, "\"", 548, 1);
#nullable restore
#line 13 "A:\Stack\Projects\petProjects\FullApp\ClientManager\ClientManagerMVC\Views\Home\UpdateUser.cshtml"
WriteAttributeValue("", 536, Model.Email, 536, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-dark\">Submit</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClientManagerMVC.JsonModels.UserJson> Html { get; private set; }
    }
}
#pragma warning restore 1591
