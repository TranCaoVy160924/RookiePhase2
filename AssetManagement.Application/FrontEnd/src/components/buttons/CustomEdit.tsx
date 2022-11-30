import React from 'react';
import { Button, useRecordContext} from 'react-admin';
import EditIcon from '@mui/icons-material/Edit';
import { Link } from 'react-router-dom';

const CEditButton = () => {
    const record = useRecordContext();

    return <Link to={`/user/${record.staffCode}`}>
        <Button variant="text" size="small" label=""><EditIcon/></Button>
    </Link>
    
}

export default CEditButton