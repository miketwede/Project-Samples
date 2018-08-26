import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
    subscriptions = [ "Basic", "Advanced", "Pro"];
    passwordPattern = "^[a-z]*$";
    errors = [];

    constructor(private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.pattern("^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$"), Validators.minLength(8)]],
            subscriptionControl: ['Advanced'],
            errorMessagesControl: ['']
        });
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
                if (this.f.password.errors.pattern)
                {
                    this.errors.push("Password must contain at least one letter and one special character.");
                }
            }
            return;
        }

        alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))
    }

    onClear() {
        if(confirm("Are you sure to abandon changes? ")) {
            this.ngOnInit();
            this.errors = [];
            this.submitted = false;
            this.emailIsDirty = false;
            this.passwordIsDirty = false;
          }
      }

      emailLostFocus() {
        this.emailIsDirty = true;
      }

      passwordLostFocus() {
        this.passwordIsDirty = true;
      }

}
