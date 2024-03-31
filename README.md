
Implementation of Mobile Number Verification Using Firebase



I Implemented the mobile verification on Admin — view —- Login.cshtml.


1 Script :

These below packages should import to 

![Capturedfd](https://github.com/SRINI-KS/Firebase-Auth/assets/97938383/1e3b8cfc-8359-44fe-be92-e74127c2e4a7)


<script src="https://www.gstatic.com/firebasejs/8.9.1/firebase-app.js"></script>
<script src="https://www.gstatic.com/firebasejs/8.9.1/firebase-auth.js"></script>
<script src="https://www.gstatic.com/firebasejs/8.9.1/firebase-analytics.js"></script>


2 Firebase Configuration:
To set up Firebase within the application environment. This involves including Firebase libraries in the project and configuring Firebase with the necessary credentials. Below is a snippet of the Firebase configuration used in the implementation:



![config](https://github.com/SRINI-KS/Firebase-Auth/assets/97938383/b7f0c4f6-a5a6-4b85-be19-c74003d80763)


const firebaseConfig = {
        apiKey: "AIzaSyCncXMV3JTJgLAmyxOW_h1pwNMpWzTa5Z4",
        authDomain: "sprovider-d2fd8.firebaseapp.com",
        databaseURL: "https://sprovider-d2fd8-default-rtdb.firebaseio.com",
        projectId: "sprovider-d2fd8",
        storageBucket: "sprovider-d2fd8.appspot.com",
        messagingSenderId: "424576630792",
        appId: "1:424576630792:web:aa1cd607fdfa7ca0be51bd",
        measurementId: "G-2J45E0Q3YF"
    };
 firebase.initializeApp(firebaseConfig);




3 Setting Up reCAPTCHA Verifier:


![capta](https://github.com/SRINI-KS/Firebase-Auth/assets/97938383/5380cad0-2dee-465d-84f7-cb393a31ae40)


Before you can sign in users with their phone numbers, you must set up Firebase's reCAPTCHA verifier.


 var recaptchaVerifier = new firebase.auth.RecaptchaVerifier('recaptcha-container', {
     'size': 'invisible',
     'callback': (response) => {
         // reCAPTCHA solved, allow signInWithPhoneNumber.
         // handle recaptcha verification success
     },
     'expired-callback': () => {
         // Response expired. Ask the user to solve reCAPTCHA again.
         // handle recaptcha verification expiration
     }
 });




4 Send a verification code to the user's phone:



![generate code](https://github.com/SRINI-KS/Firebase-Auth/assets/97938383/4493489b-2c46-4dba-854d-d233e9aa508d)

Once the reCAPTCHA verifier is set up, the application can proceed to send a verification code to the user's provided phone number. This is achieved through the signInWithPhoneNumber method provided by Firebase Authentication. Below is the code snippet responsible for sending the verification code:



 function onSignInSubmit() {
     const number = document.getElementById("phoneNumberInput").value;
     const countryCode = "+91";
     const phoneNumber = countryCode + number;
     const appVerifier = window.recaptchaVerifier;

     firebase.auth().signInWithPhoneNumber(phoneNumber, appVerifier)
             .then(function (confirmationResult) {
                 // SMS sent. Prompt user to type the code from the message
                 window.confirmationResult = confirmationResult;
             console.log(confirmationResult)

         

             }).catch(function (error) {
           //  grecaptcha.reset(window.recaptchaWidgetId);
                 console.error("Error:", error);
                 // Handle error
             });
 }




5 verification code:
After the verification code is sent to the user's phone, they are prompted to input the received code for verification. The code snippet below demonstrates how Firebase verifies the code provided by the user:
![verify code](https://github.com/SRINI-KS/Firebase-Auth/assets/97938383/8365338a-3f93-44e4-9290-d2f178fde945)


 function verifycode() {
     const code = document.getElementById("verificationCodeInput").value;
     window.confirmationResult.confirm(code).then(function (result) {
         // User signed in successfully.
         var user = result.user;
         console.log( user);
         console.log("verified");
     }).catch(function (error) {
         console.error("Error:", error);

         // Wrong code added.
     });
  }





