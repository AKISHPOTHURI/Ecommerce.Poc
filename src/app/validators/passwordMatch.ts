import { AbstractControl } from "@angular/forms"

export function passwordValid(control: AbstractControl): {[key: string]: boolean} | null {
    
    let password:any = control.get(['password'])
    let confirmPassword:any = control.get('confirmPassword')?.value;
    console.log(password);

    console.log(confirmPassword);

 
    return (password && confirmPassword && password.value !== confirmPassword.value) ? {'mismatch': true}: null;
}