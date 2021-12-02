
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>
  <title>ESI | Odisha</title>
  <!--favicon-->
  <link rel="icon" href="assets/images/favicon.ico" type="image/x-icon">
  <!-- Bootstrap core CSS-->
  <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
  <!-- animate CSS-->
  <link href="assets/css/animate.css" rel="stylesheet" type="text/css"/>
  <!-- Icons CSS-->
  <link href="assets/css/icons.css" rel="stylesheet" type="text/css"/>
  <!-- Custom Style-->
  <link href="assets/css/app-style.css" rel="stylesheet"/>
  <style>
  @media (min-width:576px) {
  .modal-dialog1 {
    max-width: 800px;
    margin: 1.75rem auto
  }
} 
   p{
    color:black;
   }

   .modaloverflow{
    height: 600px;
    overflow-y: auto;
   } 
   .overflowheight{
    height: 600px;
    overflow-y: auto;
   } 
 .rules {
    color: #b56800 !important;
    font-weight: 700;
}
    label {
    color: #00adb5;
    font-size: .75rem;
    text-transform: uppercase;
    letter-spacing: 1px;
    font-weight: 700;
    margin-bottom: 10px;
}
.btn1{
  padding: 6px 10px;
}
  </style>

</head>
<body style="background-image: url(assets/images/2.jpg); background-size: cover;">
 <!-- Start wrapper-->
 <div id="wrapper">
  <div class="card card-authentication2 mx-auto" style="margin-top: 105px;">
    <div class="card-body">
     <div class="card-content p-2 overflowheight">
      <div class="text-center pb-3"><img src="assets/images/policeblack.png" class="img-fluid"></div>
        <form>
          <div class="form-row">
            <div class="col-md-4">
              <div class="form-group">
                 <label>Function type:</label>
                    <select name="cars" id="cars" class="form-control valid" aria-invalid="false">
                    <option value="volvo">city</option>
                    <option value="saab">village</option>
                    <option value="mercedes">town</option>
                    <option value="audi">gaon</option>
                  </select>
              </div>
                    
                  </div>
          </div>
          <div class="form-row">
            <div class="col-md-4">
               <div class="form-group">
                <label>Name:</label>
          <input type="text" id="exampleInputUsername" class="form-control" placeholder="Name">
        </div>
            </div>
            <div class="col-md-4">
               <div class="form-group">
                <label>Father's Name:</label>
           <input type="text" id="exampleInputPassword" class="form-control" placeholder="Father's Name">
        </div>
            </div>
            <div class="col-md-4">
               <div class="form-group">
                <label>Phone Number:</label>
                <input type="text" id="exampleInputPassword" class="form-control" placeholder="Phone Number">
           
        </div>
            </div>
          </div>
           <div class="form-row">
            <div class="col-md-4">
               <div class="form-group">
                <label>Address:</label>
          <textarea name="" rows="2" cols="10" id="" class="form-control" required="true" ></textarea> 
        </div>
            </div>
            
          </div>
           <div class="form-row">
             <div class="col-md-4">
               <div class="form-group">
                 <label>Function Date:</label>
           <input type="Date" id="exampleInputPassword" class="form-control" placeholder="Adhaar Number">
        </div>
            </div>
            <div class="col-md-4">
               <div class="form-group">
                <label>Time From:</label>
           <input type="text" id="exampleInputPassword" class="form-control" placeholder="ESI Number">
        </div>
            </div>
             <div class="col-md-4">
               <div class="form-group">
          <label>Time To:</label>
          <input type="text" id="exampleInputPassword" class="form-control" placeholder="ESI Number">         
        </div>
            </div>
           </div>
          <div class="form-row">
             <div class="col-md-4">
               <div class="form-group">
         
         <label>Venue name & details:</label>
          <textarea name="" rows="2" cols="10" id="" class="form-control" required="true" ></textarea> 
        </div>
            </div>
           
          </div>

         <div class="form-row">
            <div class="col-md-4">
               <div class="form-group">
          <label>Total Sitting Capacity:</label>
          <input type="text" id="exampleInputPassword" class="form-control" placeholder="ESI Number">

         
        </div>
            </div>
            <div class="col-md-4">
               <div class="form-group">
         
         <label>Working place area (sqr ft/ sqr mtr):</label>
          <input type="text" id="exampleInputPassword" class="form-control" placeholder="ESI Number">
        </div>
            </div>
          </div>

         <div class="form-row">
             <div class="col-md-4">
               <div class="form-group">
         
         <label>Total no. of participants:</label>
          <input type="text" id="exampleInputPassword" class="form-control" placeholder="ESI Number"> 
        </div>
            </div>
           
          </div>

         <div class="form-row">
             <div class="col-md-4">
               <div class="form-group">
         
         <label>APPLICANT ID PROOF:</label>
          <input type="file" id="exampleInputPassword" class="form-control" placeholder="ESI Number"> 
        </div>
            </div>
           
          </div>
           <div class="form-row">
             <div class="col-md-4">
               <div class="form-group">
         
         <label>monry receipt of mandap/hotel/residence or other venue proof for use :</label>
          <input type="file" id="exampleInputPassword" class="form-control" placeholder="ESI Number"> 
        </div>
            </div>
           
          </div>
           <div class="form-row">
             <div class="col-md-12">
               <div class="form-group">
         
         <label>Total participant list :</label>
          <div>
            <div class="table-responsive">
              <table id="default-datatable" class="table table-bordered">
                <thead class="thead-dark shadow-dark">
                    <tr>
                        <th>SL NO.</th>
                        <th>NAME OF PARTICIPANT</th>
                        <th>AGE</th>
                        <th>MOBILE NO.</th>
                        <th>NATIVE DISTRICT</th>
                        <th>ACTION</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><button type="button" class="btn btn-warning btn1  m-1"><i class="fa fa-plus"></i></button></td>
                    </tr>
                     <tr>
                        <td>2</td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                        <td><input type="text" class="form-control" name=""></td>
                         <td><button type="button" class="btn btn-danger btn1  m-1"><i class="fa fa-minus"></i></button></td>
                    </tr>
                
                </tbody>
            </table>
            </div>
          </div>
          <div class="form-row">
            <div class="demo-checkbox">
                <input type="checkbox" id="user-checkbox" class="filled-in chk-col-primary" >
                <label for="user-checkbox">Agree with <a class="rules" data-toggle="modal" data-target="#fullwarningmodal">rules and regulations</a> of Govt. of Odisha/Govt. of India issued from time to
                time in connection with Covid-19</label>
        </div>
          </div>
         
          <!-- <button class="btn btn-warning m-1" data-toggle="modal" data-target="#fullwarningmodal">Warning</button> -->
        </div>
            </div>
           
          </div>
           <div class="form-row">
        <div class="col-6">
        <button type="button" class="btn btn-primary btn-round btn-block waves-effect waves-light" onclick="window.location.href = '';">Submit</button>
      </div>
       <div class="col-6">
        <button type="button" class="btn btn-primary btn-round btn-block waves-effect waves-light" onclick="window.location.href = 'index.php';">Cancel</button>
      </div>
      </div>
       <div class="modal fade" id="fullwarningmodal">
                  <div class="modal-dialog modal-dialog1">
                    <div class="modal-content bg-default border-warning modaloverflow">
                      <div class="modal-header">
                        <h5 class="modal-title text-black"><i class="fa fa-star"></i> Terms & Conditions</h5>
                        <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">×</span>
                        </button>
                      </div>
                      <div class="modal-body text-black">
                        <p>
                          <b>1.</b> That the Marriage Programme shall comply the Govt. of Odisha Office of SRC,Order
No.:2057/R&amp;DM (DM) dated 19th April 2021 The Marriage programme related gathering shall
ensure social distancing and the maximum number of guests allowed shall not be more than 50(for
the entire event) including host, family members, guests, priests and catering and other support
staff during the Marriage Programme as applied by the applicant.</p>
<p><b>2.</b> In Closed spaces, a maximum of 50% of the hall capacity will be allowed subject to the above
Ceilings .</p>
<p><b>3.</b> In Open spaces, Keeping the size of the ground/Open space view, appropriate number of persons
will be allowed, subject to the above ceilings, so as to ensure maintenance of prescribed physical
distancing norm .</p>
<p><b>4.</b> You Shall abide by the rules and regulations of Govt. of Odisha/Govt. of India issued from time to
time in connection with Covid-19 .</p>
<p><b>5.</b> At least two-meter distance to be maintained between individuals particularly in Marriage Function.</p>
<p><b>6.</b> All persons attending such functions shall put on masks.</p>
<p><b>7.</b> Persons from containment zone shall not be allowed to attend the event.</p>
<p><b>8.</b> Chewing of Gutka, Paan and Spitting in Public places is strictly prohibited.</p>
<p><b>9.</b> All religious Places/places of worship shall be closed for public Religious Congregations are strictly
prohibited.</p>
<p><b>10.</b> Provision for thermal scanning, hand wash and sanitizer will be made at all entry and exit points and
common areas.</p>

<p><b>11.</b> Frequent sanitization of entire workplace, common facilities and all points which come into human
contact e.g. door handles etc,. shall be ensured, including between shifts.</p>
<p><b>12.</b> All persons in charge of work places shall ensure social distancing through adequate distance
between participants/guest, adequate gaps between shifts, staggering the lunch breaks of staff,
etc,</p>
<p><b>13.</b> Persons above 65 years of age, persons with co-morbidities, pregnant women, and children below
the age of 10 years shall stay at home, not attended in Marriage function that strictly prohibited.</p>
<p><b>14.</b> With a view to ensuring safety in participants or guest at work places, on best effort basis should
ensure that Aarogya Setu is installed by all Participants or Guest having compatible mobile phones.
i.e Aarogya Setu enables early identification of potential risk of infection and thus acts as a shield
for individuals and the community.</p>
<p><b>15.</b> That the Marriage Function Shall originate and terminate at specified place, to the timings
indicated in the permission without obstructing the free flow of traffic. After elapse of the
duration of time herein granted if such Marriage Function etc. continues to operate, the
undersigned reserves the right to declare the said Marriage Function as unlawful and would take
action as per law with Covid-19.</p>
<p><b>16.</b> That during the Marriage Function and at the place of assembly, there shall be no inflammatory
speech or provocative sloganeering or display of placard/poster etc. which could incite communal,
caste, ethnic violence etc.</p>
<p><b>17.</b> That applicant provide sufficient drinking water, Masks, sanitization should be arranged during
Marriage Function or at the place assembly etc.</p>
<p><b>18.</b> That the applicant shall install C.C. TV on function and get recording of the entire function.</p>
<p><b>19.</b> A list of attenders of the Marriage function with contact details has to be maintained and
their contact numbers be shared with local Police Station.</p>
<p><b>20.</b> The list shall be conspicuously displayed at prominent locations of the venue which can be easily
read by public from a distance of ten(10) feet.</p>
<p><b>21.</b> FIRST AID Facility to be provided.</p>
<p><b>22.</b> That there shall not be exhibition of Fire Works to avoid public casualty during Function.</p>
<p><b>23.</b> A Nodal Person shall be identified for overseeing the arrangements and coordination at the Venue.</p>
<p><b>24.</b> The permission shall automatically be cancelled if the venue comes under contentment
Area.</p>
<p><b>25.</b> That in case of any deviation or violation of the terms and conditions, the permission so granted
shall stand automatically cancelled and the organizers, Participants or guest will be liable to be
prosecuted under the provisions of Section 51 to 60 of the Disaster Management Act,2005,
besides legal action under Sec. 188 of the IPC, and other legal provisions as applicable Extracts of
these penal provisions are At Annexure-13.
                        </p>
                        
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal"><i class="fa fa-times"></i> Close</button>
                      </div>
                    </div>
                  </div>
                </div>
           <!-- <div class="form-row">
            
          </div> -->
       
       
      <!-- <div class="form-row mr-0 ml-0">
       <div class="form-group col-md-6 col-xs-12">
         <div class="demo-checkbox">
                <input type="checkbox" id="user-checkbox" class="filled-in chk-col-primary" checked="" />
                <label for="user-checkbox">Remember me</label>
        </div>
       </div>
       <div class="form-group col-md-6 col-xs-12 text-right">
        <a href="reset-password.php">Reset Password</a>
       </div>
      </div> -->
     
      
       
       </form>
       </div>
      </div>
       </div>
    
     <!--Start Back To Top Button-->
    <a href="javaScript:void();" class="back-to-top"><i class="fa fa-angle-double-up"></i> </a>
    <!--End Back To Top Button-->
  </div><!--wrapper-->
  
  <!-- Bootstrap core JavaScript-->
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>             
  <script src="assets/js/jquery.min.js"></script>
  <script src="assets/js/popper.min.js"></script>
  <script src="assets/js/bootstrap.min.js"></script>
  
</body>

</html>
