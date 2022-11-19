import React, { useState } from 'react';
import authService from '../../services/changePasswordFirstTime/auth';
import { Form, TextInput, useLogin, useNotify } from 'react-admin';
import { Avatar, Button, Box, CssBaseline, Typography, Container } from '@mui/material';
import { createTheme, ThemeProvider, unstable_createMuiStrictModeTheme } from '@mui/material/styles';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';

const LoginPage = ({ logingIn, setLogingIn }) => {

    const [isValid, setIsValid] = useState(true);

    const login = useLogin();
    const notify = useNotify();
    let theme = createTheme();
    theme = unstable_createMuiStrictModeTheme(theme);

    const handleFormSubmit = ({ userName, password }: any) => {
        // e.preventDefault();
        setLogingIn(true);
        login({ username: userName, password: password })
            .then(data => {
                console.log(data);
                setLogingIn(false);
            })
            .catch(error => {
                setLogingIn(false);
                notify('Invalid email or password');
            });
    };

    const requiredInput = (values) => {
        const errors = {
            userName: "",
            password: "",
        };
        if (!values.userName) {
            errors.userName = "This is required";
            setIsValid(true);
        } else if (!values.password) {
            errors.password = "This is required";
            setIsValid(true);
        } else {
            setIsValid(false);
            return {};
        }
        return errors;
    }

    return (
        <ThemeProvider theme={theme}>
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Log in
                    </Typography>
                    <Box sx={{ mt: 1 }}>
                        <Form mode='onBlur' validate={requiredInput} onSubmit={handleFormSubmit}>
                            <Box
                                display="grid"
                                gap="30px"
                                gridTemplateColumns="repeat(5, minmax(0, 5fr))"
                            >
                                <TextInput
                                    fullWidth
                                    id="userName"
                                    label="User Name"
                                    name="userName"
                                    autoComplete="current-userName"
                                    autoFocus
                                    sx={{ gridColumn: "span 5" }}
                                    source="username"
                                />
                                <TextInput
                                    fullWidth
                                    id="password"
                                    label="Password"
                                    name="password"
                                    type="password"
                                    autoComplete="current-password"
                                    sx={{ gridColumn: "span 5" }}
                                    source="password"
                                />
                            </Box>
                            <Box display="flex" justifyContent="end" mt="20px">
                                <Button type="submit" color="secondary" variant="contained" disabled={isValid || logingIn}>
                                    Log in
                                </Button>
                            </Box>
                        </Form>
                    </Box>
                </Box>
            </Container>
        </ThemeProvider>
    );
};

export default LoginPage