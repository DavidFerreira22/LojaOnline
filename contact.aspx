<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="LojaOnline.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 50%;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <p class="breadcrumbs mb-0"><span class="mr-2"><a href="index.html">Home <i class="fa fa-chevron-right"></i></a></span><span>Contact Us <i class="fa fa-chevron-right"></i></span></p>
                    <h2 class="mb-0 bread">Contact Us</h2>
                </div>
            </div>
        </div>
    </section>

    <div class="contact-wrap w-100 p-md-5 p-4">
        <h3 class="mb-4">Contact Us</h3>
        <div class="contactForm">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="label" for="name">Full Name</label>
                        <input type="text" class="form-control" name="name" id="name" placeholder="Name">
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="label" for="email">Email Address</label>
                        <input type="email" class="form-control" name="email" id="email" placeholder="Email">
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="label" for="subject">Subject</label>
                        <input type="text" class="form-control" name="subject" id="subject" placeholder="Subject">
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="label" for="#">Message</label>
                        <textarea name="message" class="form-control" id="message" cols="30" rows="4" placeholder="Message"></textarea>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <input type="submit" value="Send Message" class="btn btn-primary">
                        <div class="submitting"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
