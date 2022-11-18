import * as React from 'react';
import { useLogin, useNotify } from 'react-admin';
import { Avatar, Button, Box, TextField, CssBaseline, Typography, Container } from '@mui/material';
import { createTheme, ThemeProvider, responsiveFontSizes, unstable_createMuiStrictModeTheme } from '@mui/material/styles';
import { Formik } from "formik"
import * as Yup from 'yup';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';

const LoginPage = () => {
    const login = useLogin();
    const notify = useNotify();
    let theme = createTheme();
    theme = unstable_createMuiStrictModeTheme(theme);

    const initialValues = {
        userName : "",
        password : ""
    }
    const loginSchema = Yup.object().shape({
        userName : Yup.string().required("required"),
        password : Yup.string().required("required"),
    })

    const handleFormSubmit = ({ userName, password }) => {
        // e.preventDefault();
        login({ username: userName, password: password }).catch(() =>
            notify('Invalid email or password')
        );
    };

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
                        <Formik
                            validationSchema={loginSchema}
                            initialValues={initialValues}
                            onSubmit={handleFormSubmit}
                        >
                            {({ values, errors, touched, handleBlur, handleChange, handleSubmit }) => (
                                <form onSubmit={handleSubmit}>
                                    <Box
                                        display="grid"
                                        gap="30px"
                                        gridTemplateColumns="repeat(5, minmax(0, 5fr))"
                                    >
                                        <TextField
                                            margin="0px"
                                            required
                                            fullWidth
                                            id="userName"
                                            label="User Name"
                                            name="userName"
                                            autoComplete="current-userName"
                                            autoFocus
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            defaultValue={values.userName}
                                            error={ !!touched.userName && !!errors.userName }
                                            helperText={ touched.userName && errors.userName }
                                            sx={{ gridColumn: "span 5" }}
                                        />
                                        <TextField
                                            margin="0px"
                                            required
                                            fullWidth
                                            id="password"
                                            label="Password"
                                            name="password"
                                            type="password"
                                            autoComplete="current-password"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            defaultValue={values.password}
                                            error={ !!touched.password && !!errors.password }
                                            helperText={ touched.password && errors.password }
                                            sx={{ gridColumn: "span 5" }}
                                        />
                                    </Box>
                                    <Box display="flex" justifyContent="end" mt="20px">
                                        <Button type="submit" color="secondary" variant="contained">
                                            Log in
                                        </Button>
                                    </Box>
                                </form>
                            )}
                        </Formik>
                    </Box>
                </Box>
            </Container>
        </ThemeProvider>
    );
};

export default LoginPage