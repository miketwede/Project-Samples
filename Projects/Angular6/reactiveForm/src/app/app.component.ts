import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SummaryComponent } from './summary/summary.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    selector: 'app',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {
    registerForm: FormGroup;
    submitted = false;
    emailIsDirty = false;
    passwordIsDirty = false;
    password = "";
    email = "";
    subscriptionSelected = "";
    subscriptions = [ "Basic", "Advanced", "Pro"];
    passwordPattern = "^[a-z]*$";
    errors = [];

    constructor(private router: Router, private formBuilder: FormBuilder) { }
   
    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
/*             password: ['', [Validators.required, Validators.pattern("^(?=.*[a-zA-Z])(?=.*[\W_]).{2}"), Validators.minLength(8)]],
 */            
/* password: ['', [Validators.required, Validators.pattern("^(?=.*[a-zA-Z])(?=.*[!@#$%^&*?]).{2}"), Validators.minLength(8)]],
 */
/* password: ['', [Validators.required, Validators.pattern("^(?=.*[a-zA-Z]).{1}"), Validators.minLength(8)]],
 */
/* password: ['', [Validators.required, Validators.pattern("^[A-Za-z]+$"), Validators.minLength(8)]],
 */
/* password: ['', [Validators.required, Validators.pattern("^[A-Za-z]+[0-9]+"), Validators.minLength(8)]],
 */
/* password: ['', [Validators.required, Validators.pattern("^[A-Za-z]+[!@#$%^&*()]+"), Validators.minLength(8)]],
 */password: ['', [Validators.required, Validators.pattern("^[A-Za-z]+[!@#$%^&*()]+"), Validators.minLength(8)]],
            //password: ['', [Validators.required, Validators.minLength(8)]],
            subscriptionControl: ['Advanced'],
            errorMessagesControl: ['']
        });
        this.subscriptionSelected = 'Advanced';
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;
        this.errors = [];

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            if (this.f.email.errors)
            {
                if (this.f.email.errors.required)
                {
                    this.errors.push("Email is required.");
                }
                if (this.f.email.errors.email)
                {
                    this.errors.push("Email must be a valid email address");
                }
            }

            if (this.f.password.errors)
            {
                if (this.f.password.errors.required)
                {
                    this.errors.push("Password is required.");
                }
                if (this.f.password.errors.minlength)
                {
                    this.errors.push("Password must be at least 8 characters.");
                }
                // if (this.f.password.errors.pattern)
                // {
                //     this.errors.push("Password must contain at least one letter and one special character.");
                // }     
                
                // had to resort to this ar the regex expressions in conjunction with .pattern wasn't working (at least in angular6)
                if (!this.isValidPassword(this.password))
                {
                    this.errors.push("Password must contain at least one letter and one special character.");
                }
            }
            return;
        }

///////////////////var SummaryComponent = new SummaryComponent(this.registerForm.get("subscriptionControl").value, this.registerForm.get("email").value, this.registerForm.get("password").value);

//this.router.navigate(['/summary']);
//this.router.navigate(['summary']);

this.router.navigate(['summary', { subscription: this.subscriptionSelected, email: this.email, password: this.password }]);

// this.authService.socialSignup(provider, response).subscribe(res => { console.log(this.authService.getToken()); 
//     console.log('redirecting'); **this.zone.run(() => this._router.navigate(['/register-step2']));** });


        // alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))
    }

    onClear() {
        if(confirm("Are you sure to abandon changes? ")) {
            this.ngOnInit();
            this.errors = [];
            this.submitted = false;
            this.emailIsDirty = false;
            this.passwordIsDirty = false;
            //this.registerForm.invalid = false;
            this.registerForm.reset();
          }
      }

      emailLostFocus() {
        this.emailIsDirty = true;
      }

      passwordLostFocus() {
        this.passwordIsDirty = true;
      }

      subscriptionChange(selection)
      {
        this.subscriptionSelected = selection;
      }
      isValidPassword(password)
      {
          var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
          var special = "`-=[]\;,./~!@#$%^&*()_+{}|:<>?";
          var foundLetter = false;
          var foundSpecial = false;

      for (var i=0; i<password.length; i++)
      {
        if (letters.indexOf(password[i]) > -1)
        {
            foundLetter = true;
        }
        if (special.indexOf(password[i]) > -1)
        {
            foundSpecial = true;
        }
      }

        if (foundLetter && foundSpecial)
            return true;
        else
            return false;

      }
}
