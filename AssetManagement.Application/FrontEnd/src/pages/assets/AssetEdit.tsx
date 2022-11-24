import React, { useState, useEffect } from 'react'
import { Edit, Form, TextInput, DateInput, minValue, RadioButtonGroupInput,  } from 'react-admin'
import { InputLabel ,MenuItem, Select,Box, Button, Typography, Container, CssBaseline } from '@mui/material'
import { createTheme, ThemeProvider, unstable_createMuiStrictModeTheme } from '@mui/material/styles';
import { useNavigate, useParams } from 'react-router-dom';
import * as assetService from '../../services/assets'
import * as categoryService from '../../services/category'
import CategorySelectBoxDisabled from '../../components/custom/CategorySelectBoxDisabled'
import RadioButtonGroup from '../../components/custom/RadioButtonGroupInput'


var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = String(today.getFullYear());
var currentDay = yyyy + '-' + mm + '-' + dd

function EditAssetInformations() {
    const [category, setCategory] = useState([])
    const [isValid, setIsValid] = useState(true);
    const { id } = useParams();
    const [asset, setAsset] = useState({name: null,
        specification: null,
        installedDate: null,
        state: 2,
        categoryId: 0
    });
    const navigate = useNavigate();
    let theme = createTheme();
    theme = unstable_createMuiStrictModeTheme(theme);
    // console.log(asset)
    useEffect(() => {
        categoryService.getCategory()
            .then(responseData => setCategory(responseData) )
            .catch(error => console.log(error))
        assetService.getAssetById(id)
            .then(responseData => {
                setAsset(responseData)} )
            .catch(error => console.log(error))
        }, [])
    console.log("asset", asset);
    const handleFormSubmit = (data) => {
        assetService.updateAsset(id,
            {
                name: data.name,
                specification: data.specification,
                installedDate: data.installedDate,
                state: parseInt(data.state),

            })
            // Redirect to CategoryList
            .then(reponseData => navigate("/assets"))
            // Console log error
            .catch(error => console.log(error))
    };

    const requiredInput = (values) => {
        const errors = {
            name: "",
            specification: "",
            installedDate: "",
            state: ""
        };
        if (!values.name) {
            errors.name = "This is required";
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
            <Container component="main">
                <CssBaseline />
                <Box
                    sx={{
                        margin: "auto",
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        // alignItems: 'center',
                        width: "650px"
                    }}
                >
                    <Typography component="h3" variant="h5" color="#cf2338" pb="40px" fontWeight="bold">
                        Update Asset Informations
                    </Typography>
                    <Box sx={{ mt: 1 }}>
                        <Form validate={requiredInput} onSubmit={handleFormSubmit}>
                            <Box
                                display="grid"
                                gap="30px"
                            >
                                <Box
                                    sx={{ display: "flex", flexDirection: "row", width: "650px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "220px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Name *</Typography>
                                    <TextInput
                                        fullWidth
                                        label={false}
                                        name="name"
                                        source="name"
                                        defaultValue={asset.name}
                                        style={{ width: "430px", margin: "0", padding: "0" }}
                                        helperText={false}
                                        InputLabelProps={{ shrink: false }}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "650px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "220px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Category *</Typography>
                                    {/* Custom Dropdown Selection (Category) */}
                                    <CategorySelectBoxDisabled
                                        source="category"
                                        format={(formValue) => (Array.prototype.filter.bind(category)(item => item.id===formValue))["name"]}
                                        parse=""
                                        defaultValue={asset.categoryId}
                                        disabled={true}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "650px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "220px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Specification *</Typography>
                                    <TextInput
                                        label={false}
                                        fullWidth
                                        multiline
                                        rows="3"
                                        style={{ width: "430px" }}
                                        name="specification"
                                        source="specification"
                                        helperText={false}
                                        defaultValue={ asset.specification}
                                        InputLabelProps={{ shrink: false }}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "650px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "220px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >Installed Date *</Typography>
                                    <DateInput
                                        fullWidth
                                        label=""
                                        name="installedDate"
                                        source="installedDate"
                                        InputLabelProps={{shrink: false}}
                                        onBlur={(e) => e.stopPropagation()}
                                        style={{ width:"430px" }}
                                        helperText={false}
                                        defaultValue={asset.installedDate}
                                    />
                                </Box>

                                <Box
                                    style={{ display: "flex", flexDirection: "row", width: "650px" }}
                                >
                                    <Typography
                                        variant="h6"
                                        style={{
                                            width: "220px",
                                            margin: "0",
                                            padding: "0",
                                            alignSelf: "center"
                                        }}
                                    >State *</Typography>
                                    <RadioButtonGroup 
                                        label={false}
                                        defaultValue={asset.state}
                                        name="state"
                                        source="state"
                                        choices={[
                                            { state_id: 0, state: "Available" }, 
                                            { state_id: 1, state: "Not available" },
                                            { state_id: 2, state: "WaitingForRecycling" }, 
                                            { state_id: 3, state: "Recycled" }, 
                                        ]}
                                        row={false}
                                        style={{ width:"430px"}}
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
                                    style={{ margin: "10px", backgroundColor: "#cf2338", color: "#fff" }}
                                >
                                    Save
                                </Button>
                                <Button
                                    variant="outlined"
                                    onClick={(e) => navigate("/assets")}
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

export default EditAssetInformations;