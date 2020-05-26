<html>

<head>

</head>

<body>
    <?php

if(isset($_POST['submit'])){
    $name = $_POST['name'];
    $email = $_POST['email'];
    $phone = $_POST['phone'];
    $venue = $_POST['venue'];
    $message = $_POST['message'];
    
    $body = "Message from " .$name. ", regarding " .$venue. " location. Contact them back on: " .$phone. " or " .$email. ". Their messge is: " .$message;
    
    $to_email = "test@hecomputing.co.uk";
    $subject = "Contact Request from Allstars Website";
    $headers = "From: sender\'s email";
    
    if (mail($to_email, $subject, $body, $headers)) {

         echo file_get_contents("contact.html");
        echo"<script language='javascript'>
        
        alert('Email successfully sent');
        </script>";
        
        
} else {
     echo file_get_contents("contact.html");
        echo"<script language='javascript'>
        
        alert('Email sending failed');
        </script>";
         
}
}
?>

</body>

</html>
