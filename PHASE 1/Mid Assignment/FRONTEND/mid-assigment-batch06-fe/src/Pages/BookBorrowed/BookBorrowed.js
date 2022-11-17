import { Button, Input, Space, Table, Tag } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import React, { useEffect, useState } from 'react';
import { getAllData } from '../../axiosAPIs';
import styles from './BookBorrowed.module.scss';

const BOOK_BORROWED = `BookRequests/${localStorage.getItem("userName")}`;

const BookBorrowed = () => {
    const [dataState, setDataState] = useState([]);

    const getData = async () => {
        const data = await getAllData(BOOK_BORROWED);
        setDataState(data);
    };

    useEffect(() => {
        getData();
        console.log("werwerwre",BOOK_BORROWED);
    }, [localStorage.getItem("userName")]);

    const columns = [
        {
            title: 'ID',
            dataIndex: '$id',
            key: '$id',
        },
        {
            title: 'Borrowed By',
            dataIndex: 'borrowedBy',
            key: 'borrowedBy',
            sorter: (a, b) => a.requestedBy.localeCompare(b.requestedBy),
        },
        {
            title: 'Book Was Borrowed',
            dataIndex: 'bookName',
            key: 'bookName',
            sorter: (a, b) => a.requestedDate.localeCompare(b.requestedDate),
        },
    ];

    return (
        <Content className="container">
            <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
                {' '}
                <div className={styles.headerTable}>
                    <h1>List Request</h1>
                </div>
                <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataState} />
            </Space>
        </Content>
    );
};

export default BookBorrowed;
