import * as React from "react";
import { SaveButton, Toolbar, useRedirect, useNotify, ThemeProvider } from 'react-admin';
import { Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { theme } from '../../theme';
import { formToolbarStyle } from "../../styles/formToolbarStyle";

export default ({ isEnable }) => {
    const notify = useNotify();
    const navigate = useNavigate();

    return (
        <ThemeProvider theme={theme}>
            <Toolbar sx={formToolbarStyle.toolbarStyle}>
                {isEnable ? (
                    <SaveButton
                        alwaysEnable
                        label="Save"
                        mutationOptions={{
                            onSuccess: () => {
                                localStorage.setItem("RaStore.assignments.listParams", `{"displayedFilters":{},"filter":{"states":[0,1]},"order":"ASC","page":1,"perPage":5,"sort":"noNumber"}`);
                                notify('Assignment created successfully!');
                                navigate("/assignments")
                            }
                        }
                        }
                        type="button"
                        variant="contained"
                        icon={<></>}
                        color="secondary"
                    />
                ) : (
                    <SaveButton
                        disabled
                        label="Save"
                        mutationOptions={{
                            onSuccess: () => {
                                localStorage.setItem("RaStore.assignments.listParams", `{"displayedFilters":{},"filter":{"states":[0,1]},"order":"ASC","page":1,"perPage":5,"sort":"noNumber"}`);
                                notify('Assignment created successfully!');
                                navigate("/assignments")
                            }
                        }
                        }
                        type="button"
                        variant="contained"
                        icon={<></>}
                        color="secondary"
                    />
                )}

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