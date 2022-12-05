import React, { useState, useEffect, useRef } from "react";
import { TextInput, DateInput, SimpleForm, Title, EditBase } from "react-admin";
import { useParams } from "react-router-dom";
import { Box, Typography, Container, Grid } from "@mui/material";
import {
    createTheme,
    ThemeProvider,
    unstable_createMuiStrictModeTheme,
} from "@mui/material/styles";
import { theme } from "../../theme";
import { assetProvider } from "../../providers/assetProvider/assetProvider";
import AssignmentEditToolbar from "../../components/toolbar/AssignmentEditToolbar";
import { formStyle } from "../../styles/formStyle";
import SelectAssetModal from "../../components/modal/selectAssetModal/SelectAssetModal";
import SelectUserModal from "../../components/modal/selectUserModal/SelectUserModal";
import InputWithSelectModal from "../../components/custom/InputWithSelectModal";

const AssignmentEdit = () => {
    const [isInvalid, setIsInvalid] = useState(false);
    const [assetChoiceOpen, setAssetChoiceOpen] = useState(false);
    const [assetChoicePos, setAssetChoicePos] = useState({
        left: 0,
        top: 0,
        height: 0,
    });
    const [selectedAsset, setSelectedAsset] = useState("");
    const [userChoiceOpen, setUserChoiceOpen] = useState(false);
    const [userChoicePos, setUserChoicePos] = useState({
        left: 0,
        top: 0,
        height: 0
    })
    const assetRef = useRef<HTMLElement>(null);
    const userRef = useRef<HTMLElement>(null);
    const [selectedUser, setSelectedUser] = useState("");
    const { id } = useParams();
    const { innerWidth: width, innerHeight: height } = window;
    let appTheme = createTheme(theme);
    appTheme = unstable_createMuiStrictModeTheme(appTheme);

    const toggleUserChoice = () => {
        setUserChoiceOpen(!userChoiceOpen);
    }

    const toggleAssetChoice = () => {
        setAssetChoiceOpen(!assetChoiceOpen);
    }

    useEffect(() => {
        let assetTextBox = assetRef.current;
        let userTextBox = userRef.current;

        if (assetTextBox) {
            let assetTextBoxPos = assetTextBox.getBoundingClientRect()
            setAssetChoicePos({
                left: assetTextBoxPos.left,
                top: assetTextBoxPos.top,
                height: assetTextBox.offsetHeight
            })
        }
        if (userTextBox) {
            let userTextBoxPos = userTextBox.getBoundingClientRect();
            setUserChoicePos({
                left: userTextBoxPos.left,
                top: userTextBoxPos.top,
                height: userTextBox.offsetHeight
            });
        }
    }, [])

    useEffect(() => {
        assetProvider.getOne("assignments", { id: id })
            .then((response) => {
                let updatingAssignment = response.data
                setSelectedAsset(updatingAssignment.assetCode);
                setSelectedUser(updatingAssignment.assignToAppUserStaffCode);
            })
            .catch((error) => console.log(error));
    }, []);

    const requiredInput = (values) => {
        const errors = {
            note: "",
            assignedDate: ""
        };
        let today = new Date();
        today.setDate(today.getDate() - 1);
        let yesterday = today.toISOString();
        if (!values.note) {
            errors.note = "This is required";
            setIsInvalid(true);
        } else if (!values.assignedDate) {
            errors.assignedDate = "This is required";
            setIsInvalid(true);
        } else if (values.assignedDate < yesterday) {
            errors.assignedDate = "Please select only current or future date";
            setIsInvalid(true);
        } else {
            setIsInvalid(false);
            return {};
        }
        return errors;
    };

    return (
        <ThemeProvider theme={appTheme}>
            <Title title="Manage Asset > Edit Asset" />
            <Container component="main">
                {/* <CssBaseline /> */}
                <Box sx={formStyle.boxTitleStyle}>
                    <Typography
                        component="h3"
                        variant="h5"
                        sx={formStyle.formTitle}
                    >
                        Edit Assignment
                    </Typography>
                    <EditBase
                        sx={formStyle.editBaseStyle}
                        mutationMode="pessimistic"
                    >
                        <SimpleForm
                            mode="onChange"
                            validate={requiredInput}
                            reValidateMode="onChange"
                            toolbar={<AssignmentEditToolbar isEnable={!isInvalid} />}
                        >
                            <Grid container>
                                <Box sx={formStyle.boxStyle}>
                                    <Grid item xs={4}>
                                        <Typography
                                            variant="h6"
                                            sx={formStyle.typographyStyle}
                                        >
                                            User *
                                        </Typography>
                                    </Grid>

                                    <InputWithSelectModal
                                        handleClick={toggleUserChoice}
                                        source="assignToAppUserStaffCode"
                                        innerRef={userRef}
                                    />

                                    <SelectUserModal
                                        setSelectedUser={setSelectedUser}
                                        selectedUser={selectedUser}
                                        isOpened={userChoiceOpen}
                                        toggle={toggleUserChoice}
                                        pos={userChoicePos}
                                    />
                                </Box>
                                <Box sx={formStyle.boxStyle}>
                                    <Grid item xs={4}>
                                        <Typography
                                            variant="h6"
                                            sx={formStyle.typographyStyle}
                                        >
                                            Asset *
                                        </Typography>
                                    </Grid>

                                    <InputWithSelectModal
                                        handleClick={toggleAssetChoice}
                                        source="assetCode"
                                        innerRef={assetRef}
                                    />

                                    <SelectAssetModal
                                        setSelectedAsset={setSelectedAsset}
                                        selectedAsset={selectedAsset}
                                        isOpened={assetChoiceOpen}
                                        toggle={toggleAssetChoice}
                                        pos={assetChoicePos}
                                    />
                                </Box>
                                <Box sx={formStyle.boxStyle}>
                                    <Grid item xs={4}>
                                        <Typography
                                            variant="h6"
                                            sx={formStyle.typographyStyle}
                                        >
                                            Assigned Date *
                                        </Typography>
                                    </Grid>
                                    <Grid item xs={8}>
                                        <DateInput
                                            fullWidth
                                            label=""
                                            name="assignedDate"
                                            source="assignedDate"
                                            InputLabelProps={{ shrink: false }}
                                            onBlur={(e) => e.stopPropagation()}
                                            sx={formStyle.textInputStyle}
                                            helperText={false}
                                        />
                                    </Grid>
                                </Box>

                                <Box sx={formStyle.boxStyle}>
                                    <Grid item xs={4}>
                                        <Typography
                                            variant="h6"
                                            sx={formStyle.typographyStyle}
                                        >
                                            Note *
                                        </Typography>
                                    </Grid>
                                    <Grid item xs={8}>
                                        <TextInput
                                            fullWidth
                                            label={false}
                                            multiline
                                            rows={3}
                                            name="note"
                                            source="note"
                                            sx={formStyle.textInputStyle}
                                            helperText={false}
                                            InputLabelProps={{ shrink: false }}
                                        />
                                    </Grid>
                                </Box>
                            </Grid>
                        </SimpleForm>
                    </EditBase>
                </Box>
            </Container>
        </ThemeProvider>
    );
}

export default AssignmentEdit;