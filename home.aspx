<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="LojaOnline.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="hero-wrap" style="background-image: url('images/bg_2.jpg');" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-8 d-flex align-items-end">
                    <div class="text w-100 text-center">
                        <h1 class="mb-4">Whisky do Bom Para todos os Sabores.</h1>
                        <p><a href="montra.aspx" class="btn btn-primary py-2 px-4">Shop Now</a> <a href="about.aspx" class="btn btn-white btn-outline-white py-2 px-4">Read more</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-intro">
        <div class="container">
            <div class="row no-gutters">
                <div class="col-md-4 d-flex">
                    <div class="intro d-lg-flex w-100 ftco-animate fadeInUp ftco-animated">
                        <div class="icon">
                            <span class="flaticon-support"></span>
                        </div>
                        <div class="text">
                            <h2>Online Support 24/7</h2>
                            <p>A qualquer hora, temos uma equipa a sua espera. Para o ajudar, encaminhar e recomendar!</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 d-flex">
                    <div class="intro color-1 d-lg-flex w-100 ftco-animate fadeInUp ftco-animated">
                        <div class="icon">
                            <span class="flaticon-cashback"></span>
                        </div>
                        <div class="text">
                            <h2>Money Back Guarantee</h2>
                            <p>Qualquer problema com a encomenda, é nossa politica recompensar o cliente primeiro. Sempre!</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 d-flex">
                    <div class="intro color-2 d-lg-flex w-100 ftco-animate fadeInUp ftco-animated">
                        <div class="icon">
                            <span class="flaticon-free-delivery"></span>
                        </div>
                        <div class="text">
                            <h2>Free Shipping &amp; Return</h2>
                            <p>Trate de escolher o melhor whisky, que nós tratamos do resto!</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--Start of Tawk.to Script-->
    <script type="text/javascript">
        var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
        (function () {
            var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
            s1.async = true;
            s1.src = 'https://embed.tawk.to/65524099958be55aeaaf31bc/1hf4komc2';
            s1.charset = 'UTF-8';
            s1.setAttribute('crossorigin', '*');
            s0.parentNode.insertBefore(s1, s0);
        })();
    </script>
    <!--End of Tawk.to Script-->
</asp:Content>
