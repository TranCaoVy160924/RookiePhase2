import * as React from "react";
import { SaveButton, Toolbar, useRedirect, useNotify, ThemeProvider } from 'react-admin';
import { Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { theme } from '../../theme';
import { formToolbarStyle } from "../../styles/formToolbarStyle";

const UserCreateToolbar = ({ disable }) => {
    const notify = useNotify();
    const navigate = useNavigate();
    return (
        <ThemeProvider theme={theme}>
        <Toolbar sx={formToolbarStyle.toolbarStyle} >
            <SaveButton
                label="Save"
                mutationOptions={{
                    onSuccess: () => {
                        localStorage.setItem("RaStore.user.listParams", `{"displayedFilters":{},"filter":{"states":["Admin","Staff"]},"order":"ASC","page":1,"perPage":5,"sort":"staffCode"}`)
                        notify('User created successfully!');
                        navigate("/user")
                    }}
                }
                type="button"
                variant="contained"
                icon={<></>}
                color="secondary"
                disabled={disable}
            />
            <Button
                variant="outlined"
                onClick={(e) => {
                    localStorage.setItem("RaStore.user.listParams", `{"displayedFilters":{},"filter":{"states":["Admin","Staff"]},"order":"ASC","page":1,"perPage":5,"sort":"staffCode"}`)
                    navigate("/user")
                }}
                color="secondary"
            >Cancel</Button>
        </Toolbar>
        </ThemeProvider>
    );
};
export default UserCreateToolbar;