import React, { useState, useEffect } from 'react'
import { Form, TextInput, DateInput, useNotify, minValue, RadioButtonGroupInput, ReferenceInput, SelectInput } from 'react-admin'
import { Avatar, Box, Button, Typography, Container, CssBaseline } from '@mui/material'
import { createTheme, ThemeProvider, unstable_createMuiStrictModeTheme } from '@mui/material/styles';
import { useNavigate } from 'react-router-dom';
import SelectBoxWithFormInside from '../../components/custom/SelectBoxWithFormInside'
import * as assetService from '../../services/assets'
import * as categoryService from '../../services/category'

var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = String(today.getFullYear());
var currentDay = yyyy + '-' + mm + '-' + dd

function NewCategoryCreate() {
    const [category, setCategory] = useState([])
    const [isValid, setIsValid] = useState(true);
    const notify = useNotify();
    const navigate = useNavigate();
    let theme = createTheme();
    theme = unstable_createMuiStrictModeTheme(theme);

    useEffect(() => {
        categoryService.getCategory()
            .then(responseData => setCategory(responseData))
            .catch(error => console.log(error))
    }, [])

    const handleFormSubmit = (data) => {
        // Call API (Catch error, notify error)
        assetService.createAsset(
            {
                categoryId: data.category,
                name: data.name,
                specification: data.specification,
                installedDate: data.installedDate,
                state: parseInt(data.state)
            })
            // Redirect to CategoryList
            .then(reponseData => navigate("/assets"))
            // Console log error
            .catch(error => console.log(error))

        console.log(data)
    };

    const requiredInput = (values) => {
        const errors = {
            name: "",
            category: "",
            specification: "",
            installedDate: "",
            state: ""
        };
        if (!values.name) {
            errors.name = "This is required";
            setIsValid(true);
        } else if (!values.category) {
            errors.category = "This is required";
            setIsValid(true);
        } else if (!values.specification) {
            errors.specification = "This is required";
            setIsValid(true);
        } else if (!values.state) {
            errors.state = "This is required";
            setIsValid(true);
        } else {
            setIsValid(false);
            return {};
        }
        return errors;
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
                        alignItems: 'left',
                    }}
                >
                    <Typography component="h3" variant="h5" color="#cf2338" pb="40px">
                        Create New Asset
                    </Typography>
                    <Box sx={{ mt: 1 }}>
                        <Form validate={requiredInput} onSubmit={handleFormSubmit}>
                            <Box
                                display="grid"
                                gap="30px"
                            >
                                <Box
                                    sx={{ display: "flex", flexDirection: "row", width: "550px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "120px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Name</Typography>
                                    <TextInput
                                        fullWidth
                                        label="Name"
                                        name="name"
                                        source="name"
                                        style={{ width: "430px", margin: "0", padding: "0" }}
                                        helperText={false}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "550px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "120px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Category</Typography>
                                    {/* Custom Dropdown Selection (Category) */}
                                    <SelectBoxWithFormInside
                                        // category={category}
                                        source="category"
                                        format={(formValue) => (Array.prototype.filter.bind(category)(item => item.id === formValue))["name"]}
                                        parse=""
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "550px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "120px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Specification</Typography>
                                    <TextInput
                                        fullWidth
                                        multiline
                                        rows="3"
                                        style={{ width: "430px" }}
                                        label="Specification"
                                        name="specification"
                                        source="specification"
                                        helperText={false}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "550px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "120px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Assigned Date</Typography>
                                    <DateInput
                                        fullWidth
                                        label="Installed Date"
                                        name="installedDate"
                                        source="installedDate"
                                        defaultValue={currentDay}
                                        inputProps={{ min: currentDay }}
                                        validate={minValue(currentDay)}
                                        onBlur={(e) => e.stopPropagation()}
                                        style={{ width: "430px" }}
                                        helperText={false}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "550px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "120px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Specification</Typography>
                                    <RadioButtonGroupInput
                                        // fullwidth="true"
                                        source="state"
                                        label=""
                                        choices={[{ state_id: '1', state: "Available" }, { state_id: '0', state: "Not available" }]}
                                        row={false}
                                        style={{ width: "430px" }}
                                        optionText="state"
                                        optionValue="state_id"
                                        helperText={false}
                                    />
                                </Box>
                            </Box>
                            <Box display="flex" justifyContent="end" mt="20px">
                                <Button
                                    type="submit"
                                    variant="contained"
                                    disabled={isValid}
                                    style={{ margin: "10px", backgroundColor: "#cf2338" }}
                                >
                                    Save
                                </Button>
                                <Button
                                    variant="outlined"
                                    onClick={(e) => navigate("/api/Category")}
                                    style={{ margin: "10px", color: "gray" }}
                                >
                                    Cancel
                                </Button>
                            </Box>
                        </Form>
                    </Box>
                </Box>
            </Container>
        </ThemeProvider>
    )
}

export default NewCategoryCreate