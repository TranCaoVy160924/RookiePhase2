import React, { useEffect } from "react";
import { SaveButton, Toolbar, useRedirect, useNotify, ThemeProvider } from 'react-admin';
import { Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { theme } from '../../theme';
import { formToolbarStyle } from "../../styles/formToolbarStyle";

const AssignmentEditToolbar = ({ isEnable, changed }) => {
    const notify = useNotify();
    const navigate = useNavigate();

    return (
        <ThemeProvider theme={theme}>
            <Toolbar sx={formToolbarStyle.toolbarStyle}>
                <SaveButton
                    alwaysEnable={isEnable ? changed : false}
                    disabled={!isEnable}
                    label="Save"
                    mutationOptions={{
                        onSuccess: () => {
                            localStorage.setItem("RaStore.assignments.listParams", `{"displayedFilters":{},"filter":{"states":[0,1]},"order":"ASC","page":1,"perPage":5,"sort":"noNumber"}`);
                            notify('Assignment edited successfully!');
                            navigate("/assignments")
                        }
                    }
                    }
                    type="button"
                    variant="contained"
                    icon={<></>}
                    color="secondary"
                />

                <Button
                    variant="outlined"
                    onClick={(e) => {
                        localStorage.setItem("RaStore.assignments.listParams", `{"displayedFilters":{},"filter":{"states":[0,1]},"order":"ASC","page":1,"perPage":5,"sort":"noNumber"}`);
                        navigate("/assignments")
                    }}
                    color="secondary"
                >Cancel</Button>
            </Toolbar>
        </ThemeProvider>
    );
};
export default AssignmentEditToolbar;