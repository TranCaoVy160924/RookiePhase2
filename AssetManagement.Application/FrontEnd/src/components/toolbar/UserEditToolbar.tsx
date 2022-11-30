import * as React from "react";
import {
    Toolbar,
    useNotify,
    ThemeProvider,
} from "react-admin";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { theme } from "../../theme";
import { formToolbarStyle } from "../../styles/formToolbarStyle";

const UserEditToolbar = () => {
    const navigate = useNavigate();
    return (
        <ThemeProvider theme={theme}>
            <Toolbar sx={formToolbarStyle.toolbarStyle}>
                <Button
                    // type="button"
                    variant="contained"
                    type="submit"
                    color="secondary"
                >
                    Save
                </Button>
                <Button
                    variant="outlined"
                    onClick={(e) => navigate("/user")}
                    color="secondary"
                >
                    Cancel
                </Button>
            </Toolbar>
        </ThemeProvider>
    );
};
export default UserEditToolbar;
