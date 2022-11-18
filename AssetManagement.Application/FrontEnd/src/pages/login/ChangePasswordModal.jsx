import React from 'react';
import { Grid } from '@mui/material';
import { Form, PasswordInput, SaveButton, useNotify } from 'react-admin';
import authService from "../../services/auth";
// import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
// import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

const ChangePasswordModal = ({
    loginFirstTime,
    setLoginFirstTime,
    currentPassword
}) => {
    const notify = useNotify();

    const handleChangePassword = data => {
        const newPassword = data.newPassword;
        const confirmPassword = data.confirmPassword;

        if (newPassword === confirmPassword) {
            const changePasswordRequest = {
                newPassword: data.newPassword,
                confirmPassword: data.confirmPassword,
                currentPassword
            }

            authService.changePassword(changePasswordRequest)
                .then(() => {
                    setLoginFirstTime(false);
                })
                .catch(() => {
                    notify("All field is required");
                })
        }
        else {
            notify("Confirm password must similar to new password");
        }
    }

    const style = {
        bgcolor: '#cf2338',
        color: "#fff"
    }

    return (
        <Dialog
            open={loginFirstTime}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
        >
            <DialogTitle id="alert-dialog-title" sx={style}>
                {"Change Password"}
            </DialogTitle>
            <DialogContent>
                <DialogContentText id="alert-dialog-description">
                    <DialogContentText>
                        This is the first time you login. <br />
                        You have to change the password to continue
                    </DialogContentText>
                    <Form onSubmit={handleChangePassword} id="change_password_first_login_form">
                        <Grid container>
                            <Grid item xs={12}>
                                <PasswordInput source="newPassword" fullWidth />
                            </Grid>
                            <Grid item xs={12}>
                                <PasswordInput source="confirmPassword" fullWidth />
                            </Grid>
                            <Grid item xs={12}>
                                <SaveButton sx={style} type="submit" />
                            </Grid>
                        </Grid>
                    </Form>
                </DialogContentText>
            </DialogContent>
            {/* <DialogActions>
                <Button type="submit" form="change_password_first_login_form"
                    onClick={handleChangePassword} autoFocus
                    sx={style}>
                    Agree
                </Button>
            </DialogActions> */}
        </Dialog>
    )
}

export default ChangePasswordModal;