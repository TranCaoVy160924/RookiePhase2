import * as React from "react";
import { SaveButton, Toolbar, useRedirect, useNotify, ThemeProvider } from 'react-admin';
import {Button} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import {theme} from '../../theme';
import { formToolbarStyle } from "../../styles/formToolbarStyle";

const AssetCreateToolbar = ({ disable }) => {
    const notify = useNotify();
    const navigate = useNavigate();
    return (
        <ThemeProvider theme={theme}>
        <Toolbar sx={formToolbarStyle.toolbarStyle} >
            <SaveButton
                label="Save"
                mutationOptions={{
                    onSuccess: () => {
                        localStorage.setItem("RaStore.assets.listParams", `{"displayedFilters":{},"filter":{"categories":[1,2,3],"states":["0","1","4"]},"order":"ASC","page":1,"perPage":5,"sort":"assetCode"}`);
                        notify('Asset created successfully!');
                        navigate("/assets")
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
                    localStorage.setItem("RaStore.assets.listParams", `{"displayedFilters":{},"filter":{"categories":[1,2,3],"states":["0","1","4"]},"order":"ASC","page":1,"perPage":5,"sort":"assetCode"}`);
                    navigate("/assets")
                }}
                color="secondary"
            >Cancel</Button>
        </Toolbar>
        </ThemeProvider>
    );
};
export default AssetCreateToolbar;