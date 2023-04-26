import { AbstractControl, FormControl } from "@angular/forms"

export const passwordValid=(control: AbstractControl): {[key: string]: boolean} | null => {
    
    const confirmPassword = control.get(['confirmPassword'])
    const password = control.get(['password'])

    console.log(password?.value)
    console.log(confirmPassword?.value);
    if (!confirmPassword || !password) {
        return null;
    }

 
    return (password && confirmPassword && password?.value === confirmPassword?.value) ? null : {mismatch: true};
}