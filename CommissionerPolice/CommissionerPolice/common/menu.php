 <!--Start sidebar-wrapper-->
   <div id="sidebar-wrapper" data-simplebar="" data-simplebar-auto-hide="true">
     <div class="brand-logo">
      <a href="index.php">
       <img src="assets/images/logo-new.png" class="logo-icon" alt="ESI Odisha">
     </a>
   </div>
   <ul class="sidebar-menu do-nicescrol">
      <li>
        <a href="dashboard.php" class="waves-effect">
          <i class="icon-home"></i> <span>Dashboard</span>
        </a>
      </li>
      <li>
        <a href="javaScript:void();" class="waves-effect">
          <i class="fa fa-dashboard"></i>
          <span>Master</span> <i class="fa fa-angle-left pull-right"></i>
        </a>
        <ul class="sidebar-submenu">
      <li><a href="state-master.php"><i class="fa fa-circle-o"></i>State Master</a></li>
      <li><a href="district-master.php"><i class="fa fa-circle-o"></i>District Master</a></li>
      <li><a href="area-master.php"><i class="fa fa-circle-o"></i>Area Master</a></li>
      <li><a href="reimbursement-list.php"><i class="fa fa-circle-o"></i>Vendor Master</a></li>
      <li><a href="reimbursement-list.php"><i class="fa fa-circle-o"></i>Medicine Master</a></li>
      <li><a href="reimbursement-list.php"><i class="fa fa-circle-o"></i>Hospital Master</a></li>
      <li><a href="reimbursement-list.php"><i class="fa fa-circle-o"></i>Dispensary Master</a></li>
        </ul>
      </li>
      <li>
        <a href="javaScript:void();" class="waves-effect">
          <i class="fa fa-hospital-o"></i>
          <span>Hospital</span> <i class="fa fa-angle-left pull-right"></i>
        </a>
        <ul class="sidebar-submenu">
      <li><a href="patient-registration.php"><i class="fa fa-circle-o"></i>Patient Registration</a></li>
      <li><a href="application-list.php"><i class="fa fa-circle-o"></i>Applicants List</a></li>
      <li><a href="apply-ip.php"><i class="fa fa-circle-o"></i>Apply For I.P.</a></li>
        </ul>
      </li>
     <li>
        <a href="javaScript:void();" class="waves-effect">
          <i class="fa fa-money"></i>
          <span>Reimbursement</span> <i class="fa fa-angle-left pull-right"></i>
        </a>
        <ul class="sidebar-submenu">
      <li><a href="reimbursement-list.php"><i class="fa fa-circle-o"></i> Reimbursement List</a></li>
        </ul>
      </li>
    </ul>
   
   </div>
   <!--End sidebar-wrapper-->

<!--Start topbar header-->
<header class="topbar-nav">
 <nav class="navbar navbar-expand fixed-top bg-dark">
  <ul class="navbar-nav mr-auto align-items-center">
    <li class="nav-item">
      <a class="nav-link toggle-menu" href="javascript:void();">
       <i class="icon-menu menu-icon"></i>
     </a>
    </li>
    <li class="nav-item">
      <form class="search-bar">
        <input type="text" class="form-control" placeholder="Search">
         <a href="javascript:void();"><i class="icon-magnifier"></i></a>
      </form>
    </li>
  </ul>
     
  <ul class="navbar-nav align-items-center right-nav-link">
   
    <li class="nav-item">
      <a class="nav-link dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown" href="#">
        <span class="user-profile"><img src="assets/images/avatars/avatar.png" class="img-circle" alt="user avatar"></span>
      </a>
      <ul class="dropdown-menu dropdown-menu-right animated fadeIn">
       <li class="dropdown-item user-details">
        <a href="javaScript:void();">
           <div class="media">
             <div class="avatar"><img class="align-self-start mr-3" src="assets/images/avatars/avatar.png" alt="user esi odisha"></div>
            <div class="media-body">
            <h6 class="mt-2 user-title">Super Admin</h6>
            <p class="user-subtitle">admin@email.com</p>
            </div>
           </div>
          </a>
        </li>
        <li class="dropdown-divider"></li>
        <li class="dropdown-divider"></li>
        <li class="dropdown-item"><i class="icon-wallet mr-2"></i> Account</li>
        <li class="dropdown-divider"></li>
        <li class="dropdown-item"><i class="icon-settings mr-2"></i> Setting</li>
        <li class="dropdown-divider"></li>
        <a href="index.php"><li class="dropdown-item"><i class="icon-power mr-2"></i> Logout</li></a>
      </ul>
    </li>
  </ul>
</nav>
</header>
<!--End topbar header-->