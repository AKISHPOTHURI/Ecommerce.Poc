import { AbstractControl, FormControl } from "@angular/forms"

export const passwordValid=(control: AbstractControl): {[key: string]: boolean} | null => {
    
    const confirmPassword = control.get(['confirmPassword'])
    const password = control.get(['password'])

    // console.log(password?.value)
    // console.log(confirmPassword?.value);
    if (password?.value !== confirmPassword?.value) {
        confirmPassword?.setErrors({mismatch:true});
        return {mismatch: true};
    } else {
        confirmPassword?.setErrors(null);
        return null;
    }
    // if (!confirmPassword || !password) {
    //     return null;
    // }

 
    // return (password && confirmPassword && password?.value === confirmPassword?.value) ? null : {mismatch: true};
}