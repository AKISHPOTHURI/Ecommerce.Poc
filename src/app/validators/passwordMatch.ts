import { AbstractControl, FormControl } from "@angular/forms"

export const passwordValid=(control: AbstractControl): {[key: string]: boolean} | null => {
    
    const confirmPassword = control.get(['confirmPassword'])?.value
    const password = control.get(['password'])?.value

    console.log(password)
    console.log(confirmPassword);

 
    return (password && confirmPassword && password.value !== confirmPassword.value) ? {'mismatch': true}: null;
}