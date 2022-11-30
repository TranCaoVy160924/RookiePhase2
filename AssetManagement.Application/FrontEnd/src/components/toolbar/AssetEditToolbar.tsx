import * as React from "react";
import {
    SaveButton,
    Toolbar,
    useRedirect,
    useNotify,
    ThemeProvider,
    resolveRedirectTo,
} from "react-admin";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { theme } from "../../theme";
import { formToolbarStyle } from "../../styles/formToolbarStyle";

const AssetEditToolbar = ({ disable }) => {
    const notify = useNotify();
    const navigate = useNavigate();
    const redirect = useRedirect();
    return (
        <ThemeProvider theme={theme}>
            <Toolbar sx={formToolbarStyle.toolbarStyle}>
                <SaveButton
                    label="Save"
                    mutationOptions={{
                        onSuccess: () => {
                            localStorage.setItem("RaStore.assets.listParams", 
                        `{"displayedFilters":{},"filter":{},"order":"DESC","page":1,"perPage":5,"sort":"name"}`)
                            navigate("/assets")
                            notify("Element updated");
                        },
                    }}
                    type="button"
                    variant="contained"
                    icon={<></>}
                    color="secondary"
                    disabled={disable}
                />
                <Button
                    variant="outlined"
                    onClick={(e) => navigate("/assets")}
                    color="secondary"
                >
                    Cancel
                </Button>
            </Toolbar>
        </ThemeProvider>
    );
};
export default AssetEditToolbar;
